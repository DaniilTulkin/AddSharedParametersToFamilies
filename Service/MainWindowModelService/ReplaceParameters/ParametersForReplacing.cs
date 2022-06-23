using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.IO;

namespace AddSharedParametersToFamilies
{
    public partial class MainWindowModelService
    {

        internal void SelectSharedParameterForReplacing(ref string sharedParameterForReplacingName, ref ExternalDefinition selectedSharedParameterForReplacing)
        {
            try
            {
                using (SharedParametersWindow sharedParametersWindow = new SharedParametersWindow(app))
                {
                    sharedParametersWindow?.ShowDialog();
                    selectedSharedParameterForReplacing = (ExternalDefinition)sharedParametersWindow.GetDefinition();
                    sharedParameterForReplacingName = selectedSharedParameterForReplacing.Name;
                }
            }
            catch (Exception ex)
            {
            }
        }

        internal void AddPairParameters(ObservableCollection<ParametersForReplacingModel> ParametersForReplacing, 
                                              FamilyParameter selectedFamilyParameterForReplacing,
                                              ExternalDefinition selectedSharedParameterForReplacing)
        {
            if (selectedFamilyParameterForReplacing == null 
                || selectedSharedParameterForReplacing == null) return;

            if (selectedFamilyParameterForReplacing.Definition.ParameterType != selectedSharedParameterForReplacing.ParameterType
                || selectedFamilyParameterForReplacing.Definition.Name == selectedSharedParameterForReplacing.Name)
            {
                TaskDialog.Show("Ошибка создания пары параметров", "Параметры не должны иметь одинаковые имена или разные единицы измерения.");
                return;
            }

            ParametersForReplacingModel parametersForReplacing = new ParametersForReplacingModel
            {
                FamilyParameter = selectedFamilyParameterForReplacing,
                SharedParameter = selectedSharedParameterForReplacing,
                FamilyParameterName = selectedFamilyParameterForReplacing.Definition.Name,
                SharedParameterName = selectedSharedParameterForReplacing.Name
            };

            ParametersForReplacing.Add(parametersForReplacing);
        }

        internal void ReplaceParametersInDocument(ObservableCollection<ParametersForReplacingModel> parametersForReplacing,
                                                  ObservableCollection<FamilyDocumentModel> familyDocumentsForAditing)
        {
            if (!parametersForReplacing.Any() || !familyDocumentsForAditing.Any()) return;

            int i = 0;
            foreach (FamilyDocumentModel familyDocumentModel in familyDocumentsForAditing.ToList())
            {
                Document document = null;
                if (familyDocumentModel.FilePath != "OpenedFromProject")
                {
                    try
                    {
                        document = app.Application.OpenDocumentFile(familyDocumentModel.FilePath);
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    foreach (Document doc in app.Application.Documents)
                    {
                        if (doc.Title == familyDocumentModel.FileName) document = doc;
                    }
                }

                if (document != null && document.IsFamilyDocument)
                {
                    using (Transaction t = new Transaction(document, "Замена параметров"))
                    {
                        t.Start();

                        FamilyManager familyManager = document.FamilyManager;
                        IList<FamilyParameter> familyManagerParameters = familyManager.GetParameters();
                        foreach (ParametersForReplacingModel parametersForReplacingModel in parametersForReplacing)
                        {
                            foreach (FamilyParameter parameter in familyManagerParameters)
                            {
                                if (parameter.Definition.Name == parametersForReplacingModel.FamilyParameterName)
                                {
                                    try
                                    {
                                        familyManager.ReplaceParameter(parameter,
                                                                   parametersForReplacingModel.SharedParameter,
                                                                   parameter.Definition.ParameterGroup,
                                                                   parameter.IsInstance);
                                        i++;
                                    }
                                    catch (Exception)
                                    {
                                    }
                                    break;
                                }
                            }
                        }

                        t.Commit();
                    }
                }

                //familyDocumentsForAditing.Remove(familyDocumentModel);
                if (!new UIDocument(document).GetOpenUIViews().Any())
                {
                    document.Close(true);
                }
            }

            MessageBox.Show($"Параметров заменено: {i}",
                            "Замена параметров",
                            MessageBoxButtons.OK);
        }
    }
}

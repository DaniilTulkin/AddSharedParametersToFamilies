using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace AddSharedParametersToFamilies
{
    public partial class MainWindowModelService
    {
        internal void AddSharedParameter(ObservableCollection<SharedParameterModel> sharedParametersForAdding)
        {
            try
            {
                using (ParameterPropertiesWindow parameterPropertiesWindow = new ParameterPropertiesWindow(app))
                {
                    parameterPropertiesWindow.ShowDialog();
                    if (parameterPropertiesWindow.GetFamilyParameterModel() != null)
                        sharedParametersForAdding.Add(parameterPropertiesWindow.GetFamilyParameterModel());
                }
            }
            catch (Exception ex)
            {
            }
        }

        internal void AddParametersToDocument(ObservableCollection<SharedParameterModel> sharedParametersForAdding, ObservableCollection<FamilyDocumentModel> familyDocumentsForAditing)
        {
            if (!sharedParametersForAdding.Any() || !familyDocumentsForAditing.Any()) return;

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
                    using (Transaction t = new Transaction(document, "Добавление параметров"))
                    {
                        t.Start();

                        FamilyManager familyManager = document.FamilyManager;
                        List<string> familyManagerParameters = familyManager.GetParameters().Select(p => p.Definition.Name).ToList();
                        foreach (SharedParameterModel parameter in sharedParametersForAdding)
                        {
                            if (!familyManagerParameters.Contains(parameter.ExternalDefinition.Name))
                                try
                                {
                                    familyManager.AddParameter(parameter.ExternalDefinition,
                                                       parameter.BuiltInParameterGroup,
                                                       parameter.IsInstanse);
                                    i++;
                                }
                                catch (Exception)
                                {
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

            MessageBox.Show($"Параметров добавлено: {i}",
                            "Добавление параметров",
                            MessageBoxButtons.OK);
        }
    }
}

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
        internal void SaveParametersPairsSet(ObservableCollection<string> parametersPairsSets, 
                                             ObservableCollection<ParametersForReplacingModel> parametersForReplacing)
        {
            if (parametersForReplacing.Any())
            {
                string settedName = null;
                try
                {
                    using (InputSetNameWindow inputSetNameWindow = new InputSetNameWindow(app))
                    {
                        inputSetNameWindow?.ShowDialog();
                        settedName = inputSetNameWindow.viewModel.SettedName;
                        if (parametersPairsSets.Contains(settedName))
                        {
                            TaskDialog.Show("Ошибка сохранения набора параметров", "Данное имя уже существует. Введите оригинальное имя.");
                            return;
                        }
                        parametersPairsSets.Add(settedName);
                    }
                }
                catch (Exception ex)
                {
                }

                if (settedName != null)
                {
                    Json.WriteJson(parametersForReplacing, settedName, "PairsSets");
                }
            }
            return;
        }

        internal void LoadParametersPairsSet(ObservableCollection<ParametersForReplacingModel> parametersForReplacing, 
                                             string selectedParametersPairSet,
                                             ObservableCollection<FamilyDocumentModel> familyDocumentsForReplacing)
        {
            parametersForReplacing.Clear();
            DefinitionFile sharedParametersFile = doc.Application.OpenSharedParameterFile();

            if (sharedParametersFile != null)
            {
                List<ParametersForReplacingModel> parametersForReplacingModelsFromJson = Json.ReadJson<List<ParametersForReplacingModel>>(selectedParametersPairSet, "PairsSets");
                foreach (ParametersForReplacingModel parametersForReplacingModelFromJson in parametersForReplacingModelsFromJson)
                {
                    string familyParameterName = parametersForReplacingModelFromJson.FamilyParameterName;
                    string sharedParameterName = parametersForReplacingModelFromJson.SharedParameterName;

                    foreach (DefinitionGroup definitionGroup in sharedParametersFile.Groups)
                    {
                        foreach (ExternalDefinition definition in definitionGroup.Definitions)
                        {
                            if (definition.Name == sharedParameterName)
                            {
                                parametersForReplacingModelFromJson.SharedParameter = definition;
                                break;
                            }
                        }
                    }

                    foreach (Document document in app.Application.Documents)
                    {
                        foreach (FamilyDocumentModel familyDocumentModel in familyDocumentsForReplacing)
                        {
                            if (familyDocumentModel.FileName == document.Title)
                            {
                                FamilyManager familyManager = document.FamilyManager;
                                IList<FamilyParameter> familyManagerParameters = familyManager.GetParameters();

                                foreach (FamilyParameter parameter in familyManagerParameters)
                                {
                                    if (familyParameterName == parameter.Definition.Name)
                                    {
                                        parametersForReplacingModelFromJson.FamilyParameter = parameter;
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }

                    if (parametersForReplacingModelFromJson.SharedParameter != null || parametersForReplacingModelFromJson.FamilyParameter != null)
                    {
                        parametersForReplacing.Add(parametersForReplacingModelFromJson);
                    }
                }
            }
            else
            {
                TaskDialog.Show("Ошибка открытия файла общих параметров", "Файл общих параметров не подключен к проекту.");
                return;
            }
        }

        internal void DeleteParametersPairsSet(string selectedParametersPairSet, ObservableCollection<string> parametersPairsSets)
        {
            parametersPairsSets.Remove(selectedParametersPairSet);

            string filePath = Json.jsonFolderPath + $"\\PairsSets\\{selectedParametersPairSet}.json";
            if (File.Exists(filePath)) File.Delete(filePath);
        }
    }
}

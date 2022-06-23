using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.IO;

namespace AddSharedParametersToFamilies
{
    public partial class MainWindowModelService
    {
        internal void SaveParametersSet(ObservableCollection<string> sharedParametersSets, ObservableCollection<SharedParameterModel> sharedParametersForAdding)
        {
            if (sharedParametersForAdding.Any())
            {
                string settedName = null;
                try
                {
                    using (InputSetNameWindow inputSetNameWindow = new InputSetNameWindow(app))
                    {
                        inputSetNameWindow?.ShowDialog();
                        settedName = inputSetNameWindow.viewModel.SettedName;
                        if (sharedParametersSets.Contains(settedName))
                        {
                            TaskDialog.Show("Ошибка сохранения набора параметров", "Данное имя уже существует. Введите оригинальное имя.");
                            return;
                        }
                        sharedParametersSets.Add(settedName);
                    }
                }
                catch (Exception ex)
                {
                }

                if (settedName != null)
                {
                    Json.WriteJson(sharedParametersForAdding, settedName, "Sets");
                }
            }
            return;
        }

        internal void LoadParametersSet(ObservableCollection<SharedParameterModel> sharedParametersForAdding, string selectedSharedParametersSet)
        {
            sharedParametersForAdding.Clear();
            DefinitionFile sharedParametersFile = doc.Application.OpenSharedParameterFile();

            if (sharedParametersFile != null)
            {
                List<SharedParameterModel> familyParameterModelsfromJson = Json.ReadJson<List<SharedParameterModel>>(selectedSharedParametersSet, "Sets");
                foreach (SharedParameterModel familyParameterModelFromJson in familyParameterModelsfromJson)
                {
                    foreach (DefinitionGroup definitionGroup in sharedParametersFile.Groups)
                    {
                        if (definitionGroup.Name == familyParameterModelFromJson.ParameterGroup)
                        {
                            foreach (ExternalDefinition definition in definitionGroup.Definitions)
                            {
                                if (definition.Name == familyParameterModelFromJson.ParameterName)
                                {
                                    sharedParametersForAdding.Add(new SharedParameterModel
                                    {
                                        ParameterName = definition.Name,
                                        ParameterGroup = definition.OwnerGroup.Name,
                                        ExternalDefinition = definition,
                                        BuiltInParameterGroup = familyParameterModelFromJson.BuiltInParameterGroup,
                                        IsInstanse = familyParameterModelFromJson.IsInstanse
                                    });
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                TaskDialog.Show("Ошибка открытия файла общих параметров", "Файл общих параметров не подключен к проекту.");
            }
        }

        internal void DeleteParametersSet(string selectedSharedParametersSet, ObservableCollection<string> sharedParametersSets)
        {
            sharedParametersSets.Remove(selectedSharedParametersSet);

            string filePath = Json.jsonFolderPath + $"\\Sets\\{selectedSharedParametersSet}.json";
            if (File.Exists(filePath)) File.Delete(filePath);
        }
    }
}

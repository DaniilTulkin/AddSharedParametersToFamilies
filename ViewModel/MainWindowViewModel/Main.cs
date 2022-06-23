using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.IO;
using System.Windows.Input;

namespace AddSharedParametersToFamilies
{
    public partial class MainWindowViewModel : ModelBase
    {        
        private UIApplication app;

        private Document doc;

        private MainWindowModelService MainWindowModelService;

        public Action CloseAction { get; set; }

        private int selectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get
            {
                return selectedTabControlIndex;
            }
            set
            {
                selectedTabControlIndex = value;
                OnPropertyChanged("SelectedTabControlIndex");
            }
        }

        public MainWindowViewModel(UIApplication app)
        {
            this.app = app;
            doc = app.ActiveUIDocument.Document;
            MainWindowModelService = new MainWindowModelService(app);

            MainWindowModelService.AddFamilyDocumentsInformation(FamilyDocumentsForAditing, FamilyDocumentsForReplacing, FamilyParametersForReplacing);

            Json.CheckOrCreateDirectory("Sets");
            foreach (FileInfo file in new DirectoryInfo($"{Json.jsonFolderPath}\\Sets").GetFiles("*.json"))
            {
                SharedParametersSets.Add(Path.GetFileNameWithoutExtension(file.Name));
            }

            Json.CheckOrCreateDirectory("PairsSets");
            foreach (FileInfo file in new DirectoryInfo($"{Json.jsonFolderPath}\\PairsSets").GetFiles("*.json"))
            {
                ParametersPairsSets.Add(Path.GetFileNameWithoutExtension(file.Name));
            }
        }

        public ICommand btnOK => new RelayCommandWithoutParameter(OnbtnOK);
        private void OnbtnOK()
        {
            switch (selectedTabControlIndex)
            {
                case 0:
                    MainWindowModelService.AddParametersToDocument(SharedParametersForAdding, FamilyDocumentsForAditing);
                    break;
                case 1:
                    MainWindowModelService.ReplaceParametersInDocument(ParametersForReplacing, FamilyDocumentsForAditing);
                    break;
                default:
                    break;
            }
        }

        public ICommand btnCancel => new RelayCommandWithoutParameter(OnbtnCancel);
        private void OnbtnCancel()
        {
            CloseAction();
        }
    }
}

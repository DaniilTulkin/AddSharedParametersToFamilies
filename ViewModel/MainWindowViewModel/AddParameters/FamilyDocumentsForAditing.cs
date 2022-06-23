using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AddSharedParametersToFamilies
{
    public partial class MainWindowViewModel : ModelBase
    {
        private ObservableCollection<FamilyDocumentModel> familyDocumentsForAditing = new ObservableCollection<FamilyDocumentModel>();
        public ObservableCollection<FamilyDocumentModel> FamilyDocumentsForAditing
        {
            get
            {
                return familyDocumentsForAditing;
            }
            set
            {
                familyDocumentsForAditing = value;
                OnPropertyChanged("FamilyDocumentsForAditing");
            }
        }

        private FamilyDocumentModel selectedFamilyDocumentForAditing;
        public FamilyDocumentModel SelectedFamilyDocumentForAditing
        {
            get
            {
                return selectedFamilyDocumentForAditing;
            }
            set
            {
                selectedFamilyDocumentForAditing = value;
                OnPropertyChanged("SelectedFamilyDocumentForAditing");
            }
        }

        public ICommand btnAddFamilyDocument => new RelayCommandWithoutParameter(OnbtnAddFamilyDocument);
        private void OnbtnAddFamilyDocument()
        {
            List<FamilyDocumentModel> familyDocumentModels = MainWindowModelService.OpenFamilyDocuments();

            if (familyDocumentModels != null)
            {
                foreach (FamilyDocumentModel familyDocumentModel in familyDocumentModels)
                {
                    familyDocumentsForAditing.Add(familyDocumentModel);
                }
            }
        }

        public ICommand btnRemoveFamilyDocument => new RelayCommandWithoutParameter(OnbtnRemoveFamilyDocument);
        private void OnbtnRemoveFamilyDocument()
        {
            familyDocumentsForAditing.Remove(selectedFamilyDocumentForAditing);
        }
    }
}

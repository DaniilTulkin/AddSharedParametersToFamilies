using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AddSharedParametersToFamilies
{
    public partial class MainWindowViewModel : ModelBase
    {
        private ObservableCollection<FamilyDocumentModel> familyDocumentsForReplacing = new ObservableCollection<FamilyDocumentModel>();
        public ObservableCollection<FamilyDocumentModel> FamilyDocumentsForReplacing
        {
            get
            {
                return familyDocumentsForReplacing;
            }
            set
            {
                familyDocumentsForReplacing = value;
                OnPropertyChanged("FamilyDocumentsForReplacing");
            }
        }

        private FamilyDocumentModel selectedFamilyDocumentForReplacing;
        public FamilyDocumentModel SelectedFamilyDocumentForReplacing
        {
            get
            {
                return selectedFamilyDocumentForReplacing;
            }
            set
            {
                selectedFamilyDocumentForReplacing = value;
                OnPropertyChanged("SelectedFamilyDocumentForReplacing");
            }
        }

        public ICommand btnRemoveFamilyDocumentForReplacing => new RelayCommandWithoutParameter(OnbtnRemoveFamilyDocumentForReplacing);
        private void OnbtnRemoveFamilyDocumentForReplacing()
        {
            FamilyDocumentsForReplacing.Remove(SelectedFamilyDocumentForReplacing);
        }
    }
}

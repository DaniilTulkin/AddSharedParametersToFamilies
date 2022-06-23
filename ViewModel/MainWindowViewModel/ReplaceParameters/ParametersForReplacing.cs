using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AddSharedParametersToFamilies
{
    public partial class MainWindowViewModel : ModelBase
    {
        private ObservableCollection<FamilyParameter> familyParametersForReplacing = new ObservableCollection<FamilyParameter>();
        public ObservableCollection<FamilyParameter> FamilyParametersForReplacing
        {
            get
            {
                return familyParametersForReplacing;
            }
            set
            {
                familyParametersForReplacing = value;
                OnPropertyChanged("FamilyParametersForReplacing");
            }
        }

        private string sharedParameterForReplacingName;
        public string SharedParameterForReplacingName
        {
            get
            {
                return sharedParameterForReplacingName;
            }
            set
            {
                sharedParameterForReplacingName = value;
                OnPropertyChanged("SharedParameterForReplacingName");
            }
        }

        private ExternalDefinition selectedSharedParameterForReplacing;
        public ExternalDefinition SelectedSharedParameterForReplacing
        {
            get
            {
                return selectedSharedParameterForReplacing;
            }
            set
            {
                selectedSharedParameterForReplacing = value;
            }
        }

        private FamilyParameter selectedFamilyParameterForReplacing;
        public FamilyParameter SelectedFamilyParameterForReplacing
        {
            get
            {
                return selectedFamilyParameterForReplacing;
            }
            set
            {
                selectedFamilyParameterForReplacing = value;
                OnPropertyChanged("SelectedFamilyParameterForReplacing");
            }
        }

        private ObservableCollection<ParametersForReplacingModel> parametersForReplacing = new ObservableCollection<ParametersForReplacingModel>();
        public ObservableCollection<ParametersForReplacingModel> ParametersForReplacing
        {
            get
            {
                return parametersForReplacing;
            }
            set
            {
                parametersForReplacing = value;
                OnPropertyChanged("ParametersForReplacing");
            }
        }

        private ParametersForReplacingModel selectedParametersForReplacing;
        public ParametersForReplacingModel SelectedParametersForReplacing
        {
            get
            {
                return selectedParametersForReplacing;
            }
            set
            {
                selectedParametersForReplacing = value;
                OnPropertyChanged("SelectedParametersForReplacing");
            }
        }

        public ICommand btnSelectSharedParameterForReplacing => new RelayCommandWithoutParameter(OnbtnSelectSharedParameterForReplacing);
        private void OnbtnSelectSharedParameterForReplacing()
        {
            MainWindowModelService.SelectSharedParameterForReplacing(ref sharedParameterForReplacingName, ref selectedSharedParameterForReplacing);
            SharedParameterForReplacingName = sharedParameterForReplacingName;
            SelectedSharedParameterForReplacing = selectedSharedParameterForReplacing;
        }

        public ICommand btnAddPairParameters => new RelayCommandWithoutParameter(OnbtnAddPairParameters);
        private void OnbtnAddPairParameters()
        {
            MainWindowModelService.AddPairParameters(ParametersForReplacing, SelectedFamilyParameterForReplacing, SelectedSharedParameterForReplacing);
        }

        public ICommand btnRemovePairParameters => new RelayCommandWithoutParameter(OnbtnRemovePairParameters);
        private void OnbtnRemovePairParameters()
        {
            ParametersForReplacing.Remove(SelectedParametersForReplacing);
        }
    }
}

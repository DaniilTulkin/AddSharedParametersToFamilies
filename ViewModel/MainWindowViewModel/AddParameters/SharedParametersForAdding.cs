using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AddSharedParametersToFamilies
{
    public partial class MainWindowViewModel : ModelBase
    {
        private ObservableCollection<SharedParameterModel> sharedParametersForAdding = new ObservableCollection<SharedParameterModel>();
        public ObservableCollection<SharedParameterModel> SharedParametersForAdding
        {
            get
            {
                return sharedParametersForAdding;
            }
            set
            {
                sharedParametersForAdding = value;
                OnPropertyChanged("SharedParametersForAdding");
            }
        }

        private SharedParameterModel selectedSharedParameterForAdding;
        public SharedParameterModel SelectedSharedParameterForAdding
        {
            get
            {
                return selectedSharedParameterForAdding;
            }
            set
            {
                selectedSharedParameterForAdding = value;
                OnPropertyChanged("SelectedSharedParameterForAdding");
            }
        }

        public ICommand btnAddSharedParameter => new RelayCommandWithoutParameter(OnbtnAddSharedParameter);
        private void OnbtnAddSharedParameter()
        {
            MainWindowModelService.AddSharedParameter(SharedParametersForAdding);
        }

        public ICommand btnRemoveSharedParameter => new RelayCommandWithoutParameter(OnbtnRemoveSharedParameter);
        private void OnbtnRemoveSharedParameter()
        {
            sharedParametersForAdding.Remove(selectedSharedParameterForAdding);
        }
    }
}

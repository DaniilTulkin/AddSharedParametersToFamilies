using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AddSharedParametersToFamilies
{
    public partial class MainWindowViewModel : ModelBase
    {
        private ObservableCollection<string> sharedParametersSets = new ObservableCollection<string>();
        public ObservableCollection<string> SharedParametersSets
        {
            get
            {
                return sharedParametersSets;
            }
            set
            {
                sharedParametersSets = value;
                OnPropertyChanged("SharedParametersSets");
            }
        }

        private string selectedSharedParametersSet;
        public string SelectedSharedParametersSet
        {
            get
            {
                return selectedSharedParametersSet;
            }
            set
            {
                selectedSharedParametersSet = value;
                OnPropertyChanged("SelectedSharedParametersSet");
            }
        }

        public ICommand btnSave => new RelayCommandWithoutParameter(OnbtnSave);
        private void OnbtnSave()
        {
            MainWindowModelService.SaveParametersSet(sharedParametersSets, sharedParametersForAdding);
        }

        public ICommand btnLoad => new RelayCommandWithoutParameter(OnbtnLoad);
        private void OnbtnLoad()
        {
            if (selectedSharedParametersSet != null)
                MainWindowModelService.LoadParametersSet(sharedParametersForAdding, selectedSharedParametersSet);
        }

        public ICommand btnDeleteParametersSet => new RelayCommandWithoutParameter(OnbtnDeleteParametersSet);
        private void OnbtnDeleteParametersSet()
        {
            if (selectedSharedParametersSet != null)
                MainWindowModelService.DeleteParametersSet(selectedSharedParametersSet, sharedParametersSets);
        }
    }
}

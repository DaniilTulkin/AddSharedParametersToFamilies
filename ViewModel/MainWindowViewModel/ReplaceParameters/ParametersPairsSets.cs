using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AddSharedParametersToFamilies
{
    public partial class MainWindowViewModel : ModelBase
    {
        private ObservableCollection<string> parametersPairsSets = new ObservableCollection<string>();
        public ObservableCollection<string> ParametersPairsSets
        {
            get
            {
                return parametersPairsSets;
            }
            set
            {
                parametersPairsSets = value;
                OnPropertyChanged("ParametersPairsSets");
            }
        }

        private string selectedParametersPairSet;
        public string SelectedParametersPairSet
        {
            get
            {
                return selectedParametersPairSet;
            }
            set
            {
                selectedParametersPairSet = value;
                OnPropertyChanged("SelectedParametersPairSet");
            }
        }

        public ICommand btnSaveParametersPairsSet => new RelayCommandWithoutParameter(OnbtnSaveParametersPairsSet);
        private void OnbtnSaveParametersPairsSet()
        {
            MainWindowModelService.SaveParametersPairsSet(ParametersPairsSets, ParametersForReplacing);
        }

        public ICommand btnLoadParametersPairsSet => new RelayCommandWithoutParameter(OnbtnLoadParametersPairsSet);
        private void OnbtnLoadParametersPairsSet()
        {
            if (selectedParametersPairSet != null)
                MainWindowModelService.LoadParametersPairsSet(ParametersForReplacing, SelectedParametersPairSet, FamilyDocumentsForReplacing);
        }

        public ICommand btnDeleteParametersPairsSet => new RelayCommandWithoutParameter(OnbtnDeleteParametersPairsSet);
        private void OnbtnDeleteParametersPairsSet()
        {
            if (selectedParametersPairSet != null)
                MainWindowModelService.DeleteParametersPairsSet(selectedParametersPairSet, parametersPairsSets);
        }
    }
}

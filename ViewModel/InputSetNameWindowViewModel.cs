using Autodesk.Revit.UI;
using System;
using System.Windows.Input;

namespace AddSharedParametersToFamilies
{
    public class InputSetNameWindowViewModel : ModelBase
    {
        private UIApplication app;

        public Action CloseAction { get; set; }

        private string settedName;
        public string SettedName
        {
            get
            {
                return settedName;
            }
            set
            {
                settedName = value;
                OnPropertyChanged("SettedName");
            }
        }

        public InputSetNameWindowViewModel(UIApplication app)
        {
            this.app = app;
        }

        public ICommand btnOK => new RelayCommandWithoutParameter(OnbtnOK);
        private void OnbtnOK()
        {
            CloseAction();
        }

        public ICommand btnCancel => new RelayCommandWithoutParameter(OnbtnCancel);
        private void OnbtnCancel()
        {
            settedName = null;
            CloseAction();
        }
    }
}

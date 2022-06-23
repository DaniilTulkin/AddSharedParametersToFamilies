using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace AddSharedParametersToFamilies
{
    public class SharedParametersWindowViewModel : ModelBase
    {
        private SharedParametersWindowModelService SharedParametersWindowModelService;

        private List<string> groupsOfSharedParameters;
        public List<string> GroupsOfSharedParameters
        {
            get
            {
                return groupsOfSharedParameters;
            }
            set
            {
                groupsOfSharedParameters = value;
                OnPropertyChanged("GroupsOfSharedParameters");
            }
        }

        private string selectedGroupOfSharedParameters;
        public string SelectedGroupOfSharedParameters
        {
            get
            {
                return selectedGroupOfSharedParameters;
            }
            set
            {
                selectedGroupOfSharedParameters = value;
                OnPropertyChanged("SelectedGroupOfSharedParameters");
            }
        }

        private List<Definition> listOfSharedParameters;
        public List<Definition> ListOfSharedParameters
        {
            get
            {
                return listOfSharedParameters;
            }
            set
            {
                listOfSharedParameters = value;
                OnPropertyChanged("ListOfSharedParameters");
            }
        }

        private Definition selectedSharedParameter;
        public Definition SelectedSharedParameter
        {
            get
            {
                return selectedSharedParameter;
            }
            set
            {
                selectedSharedParameter = value;
                OnPropertyChanged("SelectedSharedParameter");
            }
        }

        public Action CloseAction { get; set; }

        public SharedParametersWindowViewModel(UIApplication app)
        {
            SharedParametersWindowModelService = new SharedParametersWindowModelService(app);

            GroupsOfSharedParameters = SharedParametersWindowModelService.GetGroupsOfSharedParameters();
            if (GroupsOfSharedParameters != null)
            {
                SelectedGroupOfSharedParameters = GroupsOfSharedParameters[0];
                OncmbSelectionChanged();
            }
        }

        public ICommand cmbSelectionChanged => new RelayCommandWithoutParameter(OncmbSelectionChanged);
        private void OncmbSelectionChanged()
        {
            ListOfSharedParameters = SharedParametersWindowModelService.GetListOfSharedParameters(SelectedGroupOfSharedParameters);
        }

        public ICommand btnOk => new RelayCommandWithoutParameter(OnbtnOk);
        private void OnbtnOk()
        {
            CloseAction();
        }

        public ICommand btnClose => new RelayCommandWithoutParameter(OnbtnClose);

        private void OnbtnClose()
        {
            selectedSharedParameter = null;
            CloseAction();
        }
    }
}

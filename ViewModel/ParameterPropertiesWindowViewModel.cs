using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace AddSharedParametersToFamilies
{
    public class ParameterPropertiesWindowViewModel : ModelBase
    {
        private UIApplication app;

        private ExternalDefinition selectedSharedParameter;

        public Action CloseAction { get; set; }

        public ExternalDefinition SelectedSharedParameter
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

        private string parameterName;
        public string ParameterName
        {
            get
            {
                return parameterName;
            }
            set
            {
                parameterName = value;
                OnPropertyChanged("ParameterName");
            }
        }

        private List<string> parameterClasses = new List<string>
        {
            "Общие",
            "Несущие конструкции",
            "ОВК",
            "Электросети",
            "Трубопроводы",
            "Энергия"
        };
        public List<string> ParameterClasses
        {
            get
            {
                return parameterClasses;
            }
            set
            {
                parameterClasses = value;
                OnPropertyChanged("ParameterClasses");
            }
        }

        private string selectedParameterClass;
        public string SelectedParameterClass
        {
            get
            {
                return selectedParameterClass;
            }
            set
            {
                selectedParameterClass = value;
                OnPropertyChanged("SelectedParameterClass");
            }
        }

        private List<string> parameterTypes = new List<string>();
        public List<string> ParameterTypes
        {
            get
            {
                return parameterTypes;
            }
            set
            {
                parameterTypes = value;
                OnPropertyChanged("ParameterTypes");
            }
        }

        private string selectedParameterType;
        public string SelectedParameterType
        {
            get
            {
                return selectedParameterType;
            }
            set
            {
                selectedParameterType = value;
                OnPropertyChanged("SelectedParameterType");
            }
        }

        private List<string> parameterGroups = new List<string>();
        public List<string> ParameterGroups
        {
            get
            {
                return parameterGroups;
            }
            set
            {
                parameterGroups = value;
                OnPropertyChanged("ParameterGroups");
            }
        }

        private string selectedParameterGroup;
        public string SelectedParameterGroup
        {
            get
            {
                return selectedParameterGroup;
            }
            set
            {
                selectedParameterGroup = value;
                OnPropertyChanged("SelectedParameterGroup");
            }
        }

        private string parameterDescription;
        public string ParameterDescription
        {
            get
            {
                return parameterDescription;
            }
            set
            {
                parameterDescription = value;
                OnPropertyChanged("ParameterDescription");
            }
        }

        private bool isInstance = false;
        public bool IsInstanse
        {
            get
            {
                return isInstance;
            }
            set
            {
                isInstance = value;
                OnPropertyChanged("IsInstanse");
            }
        }

        public ParameterPropertiesWindowViewModel(UIApplication app)
        {
            this.app = app;

            foreach (ParameterType parameterType in Enum.GetValues(typeof(ParameterType)))
            {
                string typeRus = ParameterTypeRus.ToRus(parameterType);
                if (typeRus != null) parameterTypes.Add(typeRus);
            }

            foreach (BuiltInParameterGroup parameterGroup in Enum.GetValues(typeof(BuiltInParameterGroup)))
            {
                string groupRus = BuiltInParameterGroupRus.ToRus(parameterGroup);
                if (groupRus != null) parameterGroups.Add(groupRus);
            }
            parameterGroups.Sort((x, y) => string.Compare(x, y));
            selectedParameterGroup = parameterGroups[0];
        }

        public ICommand btnChoose => new RelayCommandWithoutParameter(OnbtnChoose);
        private void OnbtnChoose()
        {
            try
            {
                using (SharedParametersWindow sharedParametersWindow = new SharedParametersWindow(app))
                {
                    sharedParametersWindow?.ShowDialog();
                    selectedSharedParameter = (ExternalDefinition)sharedParametersWindow.GetDefinition();
                }
            }
            catch (Exception ex)
            {
            }

            if (selectedSharedParameter != null)
            {
                ParameterName = selectedSharedParameter.Name;
                SelectedParameterClass = UnitGroupRus.ToRus(UnitUtils.GetUnitGroup(selectedSharedParameter.UnitType));
                SelectedParameterType = ParameterTypeRus.ToRus(selectedSharedParameter.ParameterType);
                ParameterDescription = selectedSharedParameter.Description;
            }
        }

        public ICommand rdbType => new RelayCommandWithoutParameter(OnrdbType);
        private void OnrdbType()
        {
            isInstance = false;
        }

        public ICommand rdbInstance => new RelayCommandWithoutParameter(OnrdbInstance);
        private void OnrdbInstance()
        {
            isInstance = true;
        }

        public ICommand btnOk => new RelayCommandWithoutParameter(OnbtnOk);
        private void OnbtnOk()
        {
            CloseAction();
        }

        public ICommand btnClose => new RelayCommandWithoutParameter(OnbtnClose);

        private void OnbtnClose()
        {
            SelectedSharedParameter = null;
            CloseAction();
        }
    }
}

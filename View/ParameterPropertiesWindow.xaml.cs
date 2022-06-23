using Autodesk.Revit.UI;
using System;
using System.Windows;
using System.Windows.Input;

namespace AddSharedParametersToFamilies
{
    /// <summary>
    /// Interaction logic for ParameterPropertiesWindow.xaml
    /// </summary>
    public partial class ParameterPropertiesWindow : Window, IDisposable
    {
        private ParameterPropertiesWindowViewModel viewModel;

        public ParameterPropertiesWindow(UIApplication app)
        {
            InitializeComponent();
            viewModel = new ParameterPropertiesWindowViewModel(app);
            this.DataContext = viewModel;

            if (viewModel.CloseAction == null) viewModel.CloseAction = new Action(this.Close);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        public SharedParameterModel GetFamilyParameterModel()
        {
            if (viewModel.SelectedSharedParameter == null) return null;
            return new SharedParameterModel
            {
                ParameterName = viewModel.SelectedSharedParameter.Name,
                ParameterGroup = viewModel.SelectedSharedParameter.OwnerGroup.Name,
                ExternalDefinition = viewModel.SelectedSharedParameter,
                BuiltInParameterGroup = BuiltInParameterGroupRus.ToEng(viewModel.SelectedParameterGroup),
                IsInstanse = viewModel.IsInstanse
            };
        }

        public void Dispose()
        {

        }
    }
}

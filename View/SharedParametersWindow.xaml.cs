using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Windows;
using System.Windows.Input;

namespace AddSharedParametersToFamilies
{
    /// <summary>
    /// Interaction logic for SharedParametersWindow.xaml
    /// </summary>
    public partial class SharedParametersWindow : Window, IDisposable
    {
        private SharedParametersWindowViewModel viewModel;

        public SharedParametersWindow(UIApplication app)
        {
            InitializeComponent();
            viewModel = new SharedParametersWindowViewModel(app);
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

        public Definition GetDefinition()
        {
            return viewModel.SelectedSharedParameter;
        }
        public void Dispose()
        {

        }
    }
}

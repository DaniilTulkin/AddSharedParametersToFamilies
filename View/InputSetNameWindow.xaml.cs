using Autodesk.Revit.UI;
using System;
using System.Windows;
using System.Windows.Input;

namespace AddSharedParametersToFamilies
{
    /// <summary>
    /// Interaction logic for InputSetNameWindow.xaml
    /// </summary>
    public partial class InputSetNameWindow : Window, IDisposable
    {
        public InputSetNameWindowViewModel viewModel;

        public InputSetNameWindow(UIApplication app)
        {
            InitializeComponent();
            viewModel = new InputSetNameWindowViewModel(app);
            DataContext = viewModel;

            if (viewModel.CloseAction == null) viewModel.CloseAction = new Action(this.Close);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        public void Dispose()
        {

        }
    }
}

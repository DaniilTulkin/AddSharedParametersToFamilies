using Autodesk.Revit.UI;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace AddSharedParametersToFamilies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        public MainWindowViewModel viewModel;

        public MainWindow(UIApplication app)
        {
            InitializeComponent();
            viewModel = new MainWindowViewModel(app);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}

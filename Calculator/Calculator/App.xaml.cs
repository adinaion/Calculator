using Calculator.View;
using Calculator.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var viewModel = new CalculatorViewModel();

            if (viewModel.IsProgrammerMode)
            {
                var programmerWindow = new ProgrammerWindow(viewModel);
                programmerWindow.Show();
            }
            else
            {
                var mainWindow = new MainWindow(viewModel);
                mainWindow.Show();
            }
        }
    }
}

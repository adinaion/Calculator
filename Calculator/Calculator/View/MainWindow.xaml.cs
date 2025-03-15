using Calculator.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new CalculatorViewModel();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var viewModel = (CalculatorViewModel)this.DataContext;

            if (e.Key == Key.Return)
            {
                if (viewModel.EqualsCommand.CanExecute(null))
                {
                    viewModel.EqualsCommand.Execute(null);
                    Keyboard.ClearFocus();
                }
            }
            else if (e.Key == Key.Escape)
            {
                if (viewModel.ClearCommand.CanExecute(null))
                {
                    viewModel.ClearCommand.Execute(null);
                    Keyboard.ClearFocus();
                }
            }
            else if (e.Key == Key.Add)
            {
                if (viewModel.AddCommand.CanExecute("+"))
                {
                    viewModel.AddCommand.Execute("+");
                    Keyboard.ClearFocus();
                }
            }
            else if (e.Key == Key.Subtract)
            {
                if (viewModel.SubtractCommand.CanExecute("-"))
                {
                    viewModel.SubtractCommand.Execute("-");
                    Keyboard.ClearFocus();
                }
            }
            else if (e.Key == Key.Multiply)
            {
                if (viewModel.MultiplyCommand.CanExecute("*"))
                {
                    viewModel.MultiplyCommand.Execute("*");
                    Keyboard.ClearFocus();
                }
            }
            else if (e.Key == Key.Divide)
            {
                if (viewModel.DivideCommand.CanExecute("/"))
                {
                    viewModel.DivideCommand.Execute("/");
                    Keyboard.ClearFocus();
                }
            }
        }





    }
}
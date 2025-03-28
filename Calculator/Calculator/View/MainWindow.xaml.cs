﻿using Calculator.View;
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
        public MainWindow(CalculatorViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var viewModel = (CalculatorViewModel)this.DataContext;

            if (e.Key == Key.Return)
            {
                if (viewModel.EqualsCommand.CanExecute(null))
                {
                    viewModel.EqualsCommand.Execute(null);
                }
            }
            else if (e.Key == Key.Escape)
            {
                if (viewModel.ClearCommand.CanExecute(null))
                {
                    viewModel.ClearCommand.Execute(null);
                }
            }
            else if (e.Key == Key.Add)
            {
                if (viewModel.AddCommand.CanExecute("+"))
                {
                    viewModel.AddCommand.Execute("+");
                }
            }
            else if (e.Key == Key.Subtract)
            {
                if (viewModel.SubtractCommand.CanExecute("-"))
                {
                    viewModel.SubtractCommand.Execute("-");
                }
            }
            else if (e.Key == Key.Multiply)
            {
                if (viewModel.MultiplyCommand.CanExecute("*"))
                {
                    viewModel.MultiplyCommand.Execute("*");
                }
            }
            else if (e.Key == Key.Divide)
            {
                if (viewModel.DivideCommand.CanExecute("/"))
                {
                    viewModel.DivideCommand.Execute("/");
                }
            }
            else if (e.Key == Key.D0)
            {
                viewModel.AddDigitCommand.Execute("0");
            }
            else if (e.Key == Key.D1)
            {
                viewModel.AddDigitCommand.Execute("1");
            }
            else if (e.Key == Key.D2)
            {
                viewModel.AddDigitCommand.Execute("2");
            }
            else if (e.Key == Key.D3)
            {
                viewModel.AddDigitCommand.Execute("3");
            }
            else if (e.Key == Key.D4)
            {
                viewModel.AddDigitCommand.Execute("4");
            }
            else if (e.Key == Key.D5)
            {
                viewModel.AddDigitCommand.Execute("5");
            }
            else if (e.Key == Key.D6)
            {
                viewModel.AddDigitCommand.Execute("6");
            }
            else if (e.Key == Key.D7)
            {
                viewModel.AddDigitCommand.Execute("7");
            }
            else if (e.Key == Key.D8)
            {
                viewModel.AddDigitCommand.Execute("8");
            }
            else if (e.Key == Key.D9)
            {
                viewModel.AddDigitCommand.Execute("9");
            }
            else
            {
                MessageBox.Show("Tasta necunoscută apăsată: " + e.Key.ToString());
            }
        }

        private void SwitchToProgrammerMode(object sender, RoutedEventArgs e)
        {
            var viewModel = (CalculatorViewModel)this.DataContext;
            viewModel.IsProgrammerMode = true;
            
            var programmerWindow = new ProgrammerWindow(viewModel);
            programmerWindow.DataContext = viewModel;
            
            programmerWindow.Show();
            this.Close();
        }
    }
}
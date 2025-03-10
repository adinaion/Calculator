using Calculator.ViewModel.Commands;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private CalculatorModel _calculatorModel;

        public CalculatorViewModel()
        {
            _calculatorModel = new CalculatorModel();
        }

        // Display-ul care va fi legat în XAML
        public string Display => _calculatorModel.CurrentValue.ToString();

        #region Commands
        public ICommand AddDigitCommand => new RelayCommand(param => AddDigit(param));
        public ICommand AddCommand => new RelayCommand(param => ExecuteOperation("+", param));
        public ICommand SubtractCommand => new RelayCommand(param => ExecuteOperation("-", param));
        public ICommand MultiplyCommand => new RelayCommand(param => ExecuteOperation("*", param));
        public ICommand DivideCommand => new RelayCommand(param => ExecuteOperation("/", param));
        public ICommand ModulusCommand => new RelayCommand(param => ExecuteOperation("%", param));
        public ICommand SquareCommand => new RelayCommand(param => ExecuteOperation("x^2", param));
        public ICommand SquareRootCommand => new RelayCommand(param => ExecuteOperation("sqrt", param));
        public ICommand NegateCommand => new RelayCommand(param => ExecuteOperation("+/-", param));
        public ICommand InverseCommand => new RelayCommand(param => ExecuteOperation("1/x", param));
        public ICommand ClearCommand => new RelayCommand(param => Clear());

        #endregion

        private void AddDigit(object parameter)
        {
            // Dacă parametrul este o cifră, o adăugăm la valoarea curentă
            if (parameter != null && parameter is string digit)
            {
                _calculatorModel.AppendDigit(digit);  // Trimitem cifra la model
                OnPropertyChanged(nameof(Display));  // Actualizăm display-ul
            }
        }

        private void ExecuteOperation(string operation, object parameter)
        {
            try
            {
                double operand = 0;

                // Verificăm dacă butonul apăsat este un număr
                if (parameter != null && double.TryParse(parameter.ToString(), out operand))
                {
                    _calculatorModel.PerformOperation(operation, operand);
                }
                else
                {
                    _calculatorModel.PerformOperation(operation, 0); // Dacă nu avem operand, executăm fără valoare
                }

                // Actualizarea display-ului
                OnPropertyChanged(nameof(Display));
            }
            catch (Exception ex)
            {
                // Tratează erorile (ex: diviziune la 0)
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Clear()
        {
            _calculatorModel.Clear();
            OnPropertyChanged(nameof(Display));
        }

        // Implementarea INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

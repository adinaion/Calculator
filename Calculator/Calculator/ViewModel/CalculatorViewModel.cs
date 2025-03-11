using Calculator.ViewModel.Commands;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private CalculatorModel _calculatorModel;
        private string _currentOperation;
        private bool _operationPressed;

        public CalculatorViewModel()
        {
            _calculatorModel = new CalculatorModel();
            _currentOperation = string.Empty;
            _operationPressed = false;
        }

        public string Display => _calculatorModel.CurrentValue;

        #region Commands
        public ICommand AddDigitCommand => new RelayCommand(param => AddDigit(param));
        public ICommand AddCommand => new RelayCommand(param => ExecuteOperation(param));
        public ICommand SubtractCommand => new RelayCommand(param => ExecuteOperation(param));
        public ICommand MultiplyCommand => new RelayCommand(param => ExecuteOperation(param));
        public ICommand DivideCommand => new RelayCommand(param => ExecuteOperation(param));
        public ICommand EqualsCommand => new RelayCommand(param => CalculateResult());
        public ICommand ClearCommand => new RelayCommand(param => Clear());
        #endregion

        private void AddDigit(object parameter)
        {
            if (parameter != null && parameter is string digit)
            {
                _calculatorModel.AppendDigit(digit);
                OnPropertyChanged(nameof(Display));
            }
        }

        private void ExecuteOperation(object parameter)
        {
            try
            {

                if (_operationPressed)
                {
                    _calculatorModel.Clear();
                }

                double operand = double.Parse(_calculatorModel.CurrentValue);

                if (string.IsNullOrEmpty(_currentOperation))
                {
                    _calculatorModel.Reset();
                }

                _calculatorModel.PerformOperation(parameter.ToString(), operand);

                _currentOperation = parameter.ToString();
                _operationPressed = true;

                OnPropertyChanged(nameof(Display));
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void CalculateResult()
        {
            try
            {
                double operand = double.Parse(_calculatorModel.CurrentValue);

                if (string.IsNullOrEmpty(_currentOperation))
                {
                    return;
                }

                _calculatorModel.PerformOperation(_currentOperation, operand);
                _currentOperation = string.Empty;

                OnPropertyChanged(nameof(Display));
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Clear()
        {
            _calculatorModel.Clear();
            _currentOperation = string.Empty;
            _operationPressed = false;
            OnPropertyChanged(nameof(Display));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

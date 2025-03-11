﻿using Calculator.ViewModel.Commands;
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

        public string Display => _calculatorModel.CurrentValue;

        #region Commands
        public ICommand AddDigitCommand => new RelayCommand(param => AddDigit(param));
        public ICommand AddCommand => new RelayCommand(param => ExecuteOperation(param));
        public ICommand SubtractCommand => new RelayCommand(param => ExecuteOperation(param));
        public ICommand MultiplyCommand => new RelayCommand(param => ExecuteOperation(param));
        public ICommand DivideCommand => new RelayCommand(param => ExecuteOperation(param));
        public ICommand ModulusCommand => new RelayCommand(param => ExecuteOperation(param));
        public ICommand EqualsCommand => new RelayCommand(param => CalculateResult());
        public ICommand ClearCommand => new RelayCommand(param => Clear());
        public ICommand ClearLastEntryCommand => new RelayCommand(param => ClearLastEntry());
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
            if (parameter != null && parameter is string operation)
            {
                _calculatorModel.PerformOperation(operation);
            }
        }

        private void CalculateResult()
        {
            _calculatorModel.CalculateResult();
            OnPropertyChanged(nameof(Display));
        }

        private void Clear()
        {
            _calculatorModel.Clear();
            OnPropertyChanged(nameof(Display));
        }

        private void ClearLastEntry()
        {
            _calculatorModel.ClearLastEntry();
            OnPropertyChanged(nameof(Display));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

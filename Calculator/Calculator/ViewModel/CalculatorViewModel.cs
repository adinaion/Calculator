using Calculator.Services;
using Calculator.ViewModel.Commands;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private CalculatorModel _calculatorModel;
        private MenuCommands _menuCommands;

        public CalculatorViewModel()
        {
            _calculatorModel = new CalculatorModel();
            var menuService = new MenuService(_calculatorModel);
            _menuCommands = new MenuCommands(menuService);

            // Abonare la evenimentul UpdateDisplay din MenuCommands
            _menuCommands.UpdateDisplay += OnDisplayUpdate;
        }

        public string Display => _calculatorModel.CurrentValue;

        public MenuCommands MenuCommands => _menuCommands;

        private void OnDisplayUpdate()
        {
            // Actualizarea display-ului atunci când evenimentul este emis
            OnPropertyChanged(nameof(Display));
        }

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
        public ICommand BackspaceCommand => new RelayCommand(param => Backspace());
        public ICommand InverseCommand => new RelayCommand(param => Inverse());
        public ICommand SquareCommand => new RelayCommand(param => Square());
        public ICommand SquareRootCommand => new RelayCommand(param => SquareRoot());
        public ICommand NegateCommand => new RelayCommand(param => Negate());
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
                OnPropertyChanged(nameof(Display));
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

        private void Backspace()
        {
            _calculatorModel.Backspace();
            OnPropertyChanged(nameof(Display));
        }

        private void Inverse()
        {
            _calculatorModel.Inverse();
            OnPropertyChanged(nameof(Display));
        }

        private void Square()
        {
            _calculatorModel.Square();
            OnPropertyChanged(nameof(Display));
        }

        private void SquareRoot()
        {
            _calculatorModel.SquareRoot();
            OnPropertyChanged(nameof(Display));
        }

        private void Negate()
        {
            _calculatorModel.Negate();
            OnPropertyChanged(nameof(Display));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

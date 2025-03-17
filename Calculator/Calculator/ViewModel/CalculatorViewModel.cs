using Calculator.Services;
using Calculator.View;
using Calculator.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private CalculatorModel _calculatorModel;
        private MenuCommands _menuCommands;
        private MemoryService _memoryService;
        private MenuService _menuService;
        private BaseConverterService _baseConverterService;

        public ObservableCollection<double> MemoryStack { get; } = new ObservableCollection<double>();

        public CalculatorViewModel()
        {
            _calculatorModel = new CalculatorModel();
            _menuService = new MenuService(_calculatorModel);
            _menuCommands = new MenuCommands(_menuService);
            _memoryService = new MemoryService();
            _baseConverterService = new BaseConverterService();

            _menuCommands.UpdateDisplay += UpdateDisplay;
        }

        public string Display => _calculatorModel.CurrentValue;

        public MenuCommands MenuCommands => _menuCommands;

        private void UpdateDisplay()
        {
            _menuService.ToggleDigitGrouping();
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

        #region External Memory Commands
        public ICommand SaveToMemoryStackCommand => new RelayCommand(param => SaveToMemoryStack());
        public ICommand ShowMemoryStackCommand => new RelayCommand(param => ShowMemoryStack());
        public ICommand RecallMemoryCommand => new RelayCommand(param => RecallMemory());
        public ICommand ClearMemoryCommand => new RelayCommand(param => ClearMemory());
        public ICommand AddToTopOfMemoryStackCommand => new RelayCommand(param => AddToTopOfMemoryStack());
        public ICommand SubtractFromTopOfMemoryStackCommand => new RelayCommand(param => SubtractFromTopOfMemoryStack());
        #endregion

        #region Internal Memory Commands
        public ICommand RemoveFromMemoryStackCommand => new RelayCommand(param => RemoveFromMemoryStack(param));
        public ICommand AddToMemoryStackCommand => new RelayCommand(param => AddToMemoryStack(param));
        public ICommand SubtractFromMemoryStackCommand => new RelayCommand(param => SubtractFromMemoryStack(param));

        #endregion

        #region Base Convertion Commands
        public ICommand ConvertToBinaryCommand => new RelayCommand(param => ConvertToBase(2));
        public ICommand ConvertToOctalCommand => new RelayCommand(param => ConvertToBase(8));
        public ICommand ConvertToDecimalCommand => new RelayCommand(param => ConvertToBase(10));
        public ICommand ConvertToHexadecimalCommand => new RelayCommand(param => ConvertToBase(16));
        #endregion

        #region Basic Calculator Operations
        private void AddDigit(object parameter)
        {
            if (parameter != null && parameter is string digit)
            {
                _calculatorModel.AppendDigit(digit);
                UpdateDisplay();
            }
        }

        private void ExecuteOperation(object parameter)
        {
            if (parameter != null && parameter is string operation)
            {
                _calculatorModel.PerformOperation(operation);
                UpdateDisplay();
            }
        }

        private void CalculateResult()
        {
            _calculatorModel.CalculateResult();
            UpdateDisplay();
        }

        private void Clear()
        {
            _calculatorModel.Clear();
            UpdateDisplay();
        }

        private void ClearLastEntry()
        {
            _calculatorModel.ClearLastEntry();
            OnPropertyChanged(nameof(Display));
        }

        private void Backspace()
        {
            _calculatorModel.Backspace();
            UpdateDisplay();
        }

        private void Inverse()
        {
            _calculatorModel.Inverse();
            UpdateDisplay();
        }

        private void Square()
        {
            _calculatorModel.Square();
            UpdateDisplay();
        }

        private void SquareRoot()
        {
            _calculatorModel.SquareRoot();
            UpdateDisplay();
        }

        private void Negate()
        {
            _calculatorModel.Negate();
            UpdateDisplay();
        }
        #endregion

        #region External Memory Operations

        private void SaveToMemoryStack()
        {
            double currentValue = double.Parse(_calculatorModel.CurrentValue);
            _memoryService.SaveToMemoryStack(currentValue);
            OnPropertyChanged(nameof(Display));
        }

        private void ShowMemoryStack()
        {
            var memoryStackWindow = new MemoryStackWindow();
            memoryStackWindow.SetMemoryStack(_memoryService.ShowMemoryStack());
            memoryStackWindow.ShowDialog();
        }

        private void RecallMemory()
        {
            double memoryValue = _memoryService.RecallMemory();
            _calculatorModel.CurrentValue = memoryValue.ToString();
            UpdateDisplay();
        }

        private void ClearMemory()
        {
            _memoryService.ClearMemory();
        }

        private void AddToTopOfMemoryStack()
        {
            double currentValue = double.Parse(_calculatorModel.CurrentValue);
            _memoryService.AddToTopOfMemoryStack(currentValue);
        }

        private void SubtractFromTopOfMemoryStack()
        {
            double currentValue = double.Parse(_calculatorModel.CurrentValue);
            _memoryService.SubtractFromTopOfMemoryStack(currentValue);
        }

        #endregion

        #region Internal Memory Operations
        private void RemoveFromMemoryStack(object parameter)
        {
            if (parameter is double value)
            {
                _memoryService.RemoveFromMemoryStack(value);
                UpdateMemoryStack();
            }
        }

        private void AddToMemoryStack(object parameter)
        {
            if (parameter is double value)
            {
                double currentValue = double.Parse(_calculatorModel.CurrentValue);
                _memoryService.AddToMemoryStack(value, currentValue);
                UpdateMemoryStack();
            }
        }

        private void SubtractFromMemoryStack(object parameter)
        {
            if (parameter is double value)
            {
                double currentValue = double.Parse(_calculatorModel.CurrentValue);
                _memoryService.SubtractFromMemoryStack(value, currentValue);
                UpdateMemoryStack();
            }
        }

        #endregion

        #region Convert Operations
        private void ConvertToBase(int baseValue)
        {
            try
            {
                int currentValueInDecimal = int.Parse(_calculatorModel.CurrentValue);
                string convertedValue = _baseConverterService.ConvertToBase(currentValueInDecimal, baseValue);

                _calculatorModel.CurrentValue = convertedValue;
                OnPropertyChanged(nameof(Display));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        private void UpdateMemoryStack()
        {
            MemoryStack.Clear();
            foreach (var value in _memoryService.ShowMemoryStack())
            {
                MemoryStack.Add(value);
            }
            OnPropertyChanged(nameof(MemoryStack));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

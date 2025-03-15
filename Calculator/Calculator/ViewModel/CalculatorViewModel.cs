using Calculator.Services;
using Calculator.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
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

        public ObservableCollection<double> MemoryStack { get; } = new ObservableCollection<double>();

        public CalculatorViewModel()
        {
            _calculatorModel = new CalculatorModel();
            var menuService = new MenuService(_calculatorModel);
            _menuCommands = new MenuCommands(menuService);
            _memoryService = new MemoryService();

            _menuCommands.UpdateDisplay += OnDisplayUpdate;
        }

        public string Display => _calculatorModel.CurrentValue;
        public MenuCommands MenuCommands => _menuCommands;

        private void OnDisplayUpdate()
        {
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

        #region Memory Commands
        public ICommand AddToMemoryCommand => new RelayCommand(param => AddToMemory());
        public ICommand SubtractFromMemoryCommand => new RelayCommand(param => SubtractFromMemory());
        public ICommand StoreInMemoryCommand => new RelayCommand(param => StoreInMemory());
        public ICommand RecallMemoryCommand => new RelayCommand(param => RecallMemory());
        public ICommand ShowMemoryStackCommand => new RelayCommand(param => ShowMemoryStack());
        public ICommand ClearMemoryStackCommand => new RelayCommand(param => ClearMemoryStack());
        public ICommand ClearMemoryCommand => new RelayCommand(param => ClearMemory());

        #endregion

        #region Basic Calculator Operations Commands
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
        #endregion

        #region Memory Operations Commands
        private void AddToMemory()
        {
            double currentValue = double.Parse(_calculatorModel.CurrentValue);
            _memoryService.AddToMemory(currentValue);
            OnPropertyChanged(nameof(Display));
        }

        private void SubtractFromMemory()
        {
            double currentValue = double.Parse(_calculatorModel.CurrentValue);
            _memoryService.SubtractFromMemory(currentValue);
            OnPropertyChanged(nameof(Display));
        }

        private void StoreInMemory()
        {
            double currentValue = double.Parse(_calculatorModel.CurrentValue);
            _memoryService.StoreInMemory(currentValue);
            OnPropertyChanged(nameof(Display));
        }

        private void RecallMemory()
        {
            _calculatorModel.CurrentValue = _memoryService.RecallMemory().ToString();
            OnPropertyChanged(nameof(Display));
        }

        private void ShowMemoryStack()
        {
            var stack = _memoryService.ShowMemoryStack();

            MemoryStack.Clear();
            foreach (var value in stack)
            {
                MemoryStack.Add(value);
            }

        }

        private void ClearMemoryStack()
        {
            _memoryService.ClearMemoryStack();
            MemoryStack.Clear();
        }

        private void ClearMemory()
        {
            _memoryService.ClearMemory();
            OnPropertyChanged(nameof(Display));
        }


        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

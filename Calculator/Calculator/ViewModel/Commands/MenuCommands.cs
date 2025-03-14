using System.Windows.Input;
using Calculator.Services;

namespace Calculator.ViewModel.Commands
{
    public class MenuCommands
    {
        private readonly MenuService _menuService;
        private readonly CalculatorViewModel _viewModel; // Referință către CalculatorViewModel pentru a actualiza display-ul

        public MenuCommands(MenuService menuService, CalculatorViewModel viewModel)
        {
            _menuService = menuService;
            _viewModel = viewModel; // Alocăm referința către CalculatorViewModel
            CutCommand = new RelayCommand(Cut);
            CopyCommand = new RelayCommand(Copy);
            PasteCommand = new RelayCommand(Paste);
            ToggleDigitGroupingCommand = new RelayCommand(ToggleDigitGrouping);
            AboutCommand = new RelayCommand(About);
        }

        public ICommand CutCommand { get; private set; }
        public ICommand CopyCommand { get; private set; }
        public ICommand PasteCommand { get; private set; }
        public ICommand ToggleDigitGroupingCommand { get; private set; }
        public ICommand AboutCommand { get; private set; }

        // Acțiunile legate de fiecare comandă
        private void Cut(object parameter)
        {
            _menuService.Cut();
            _viewModel.OnPropertyChanged(nameof(_viewModel.Display)); // Actualizăm display-ul
        }

        private void Copy(object parameter)
        {
            _menuService.Copy();
            _viewModel.OnPropertyChanged(nameof(_viewModel.Display)); // Actualizăm display-ul
        }

        private void Paste(object parameter)
        {
            _menuService.Paste();
            _viewModel.OnPropertyChanged(nameof(_viewModel.Display)); // Actualizăm display-ul
        }

        private void ToggleDigitGrouping(object parameter)
        {
            _menuService.ToggleDigitGrouping();
            _viewModel.OnPropertyChanged(nameof(_viewModel.Display)); // Actualizăm display-ul
        }

        private void About(object parameter)
        {
            _menuService.About();
        }
    }
}

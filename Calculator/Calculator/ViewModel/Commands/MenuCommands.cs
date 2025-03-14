using System.Windows.Input;
using Calculator.Services;

namespace Calculator.ViewModel.Commands
{
    public class MenuCommands
    {
        private readonly MenuService _menuService;

        public MenuCommands(MenuService menuService)
        {
            _menuService = menuService;
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
        }

        private void Copy(object parameter)
        {
            _menuService.Copy();
        }

        private void Paste(object parameter)
        {
            _menuService.Paste();
        }

        private void ToggleDigitGrouping(object parameter)
        {
            _menuService.ToggleDigitGrouping();
        }

        private void About(object parameter)
        {
            _menuService.About();
        }
    }
}

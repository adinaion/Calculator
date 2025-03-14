using Calculator.Services;
using System.Windows.Input;

namespace Calculator.ViewModel.Commands
{
    public class MenuCommands
    {
        private readonly MenuService _menuService;

        public event Action UpdateDisplay;

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

        private void Cut(object parameter)
        {
            _menuService.Cut();
            UpdateDisplay?.Invoke();
        }

        private void Copy(object parameter)
        {
            _menuService.Copy();
            UpdateDisplay?.Invoke();
        }

        private void Paste(object parameter)
        {
            _menuService.Paste();
            UpdateDisplay?.Invoke();
        }

        private void ToggleDigitGrouping(object parameter)
        {
            _menuService.ToggleDigitGrouping();
            UpdateDisplay?.Invoke();
        }

        private void About(object parameter)
        {
            _menuService.About();
        }
    }
}

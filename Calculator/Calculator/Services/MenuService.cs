namespace Calculator.Services
{
    public class MenuService
    {
        private readonly CalculatorModel _calculatorModel;
        private string _clipboard; // Clipboard intern

        public MenuService(CalculatorModel calculatorModel)
        {
            _calculatorModel = calculatorModel;
            _clipboard = string.Empty; // Inițializăm clipboard-ul ca un string gol
        }

        // Implementarea pentru Cut
        public void Cut()
        {
            _clipboard = _calculatorModel.CurrentValue; // Salvăm valoarea curentă în clipboard
            _calculatorModel.CurrentValue = "0"; // Resetăm valoarea curentă
        }

        // Implementarea pentru Copy
        public void Copy()
        {
            _clipboard = _calculatorModel.CurrentValue; // Salvăm valoarea curentă în clipboard
        }

        // Implementarea pentru Paste
        public void Paste()
        {
            if (!string.IsNullOrEmpty(_clipboard)) // Verificăm dacă există ceva în clipboard
            {
                _calculatorModel.CurrentValue = _clipboard; // Lipim valoarea din clipboard
            }
        }

        // Implementarea logicii pentru gruparea numerelor
        public void ToggleDigitGrouping()
        {
            double value = double.Parse(_calculatorModel.CurrentValue);
            _calculatorModel.CurrentValue = string.Format("{0:N0}", value); // Grupăm numerele
        }

        public void About()
        {
            System.Windows.MessageBox.Show("Calculator v1.0\nDeveloped by [Your Name]", "About", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }
    }
}

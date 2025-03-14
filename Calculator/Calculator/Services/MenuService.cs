namespace Calculator.Services
{
    public class MenuService
    {
        private readonly CalculatorModel _calculatorModel;

        public MenuService(CalculatorModel calculatorModel)
        {
            _calculatorModel = calculatorModel;
        }

        public void Cut()
        {
            // Implementarea logicii pentru Cut (de exemplu, copierea valorii curente într-un clipboard intern)
            // Poți implementa logica pentru manipularea valorii curente
        }

        public void Copy()
        {
            // Implementarea logicii pentru Copy (de exemplu, copierea valorii curente într-un clipboard)
            System.Windows.Clipboard.SetText(_calculatorModel.CurrentValue);  // Exemplu pentru copiere
        }

        public void Paste()
        {
            // Implementarea logicii pentru Paste (de exemplu, lipirea valorii din clipboard)
            if (System.Windows.Clipboard.ContainsText())
            {
                _calculatorModel.CurrentValue = System.Windows.Clipboard.GetText();  // Exemplu pentru lipire
            }
        }

        public void ToggleDigitGrouping()
        {
            // Implementarea logicii pentru gruparea numerelor
            double value = double.Parse(_calculatorModel.CurrentValue);
            _calculatorModel.CurrentValue = string.Format("{0:N0}", value);  // Exemplu pentru gruparea numerelor
        }

        public void About()
        {
            // Afișează informațiile despre aplicație
            System.Windows.MessageBox.Show("Calculator v1.0\nDeveloped by [Your Name]", "About", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }
    }
}

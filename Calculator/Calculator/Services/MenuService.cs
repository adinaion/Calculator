namespace Calculator.Services
{
    public class MenuService
    {
        private readonly CalculatorModel _calculatorModel;
        private string _clipboard;

        public MenuService(CalculatorModel calculatorModel)
        {
            _calculatorModel = calculatorModel;
            _clipboard = string.Empty;
        }

        public void Cut()
        {
            _clipboard = _calculatorModel.CurrentValue;
            _calculatorModel.CurrentValue = "0";
        }

        public void Copy()
        {
            _clipboard = _calculatorModel.CurrentValue;
        }

        public void Paste()
        {
            if (!string.IsNullOrEmpty(_clipboard))
            {
                _calculatorModel.CurrentValue = _clipboard;
            }
        }

        public void ToggleDigitGrouping()
        {
            double value = double.Parse(_calculatorModel.CurrentValue);
            _calculatorModel.CurrentValue = string.Format("{0:N0}", value);
        }

        public void About()
        {
            System.Windows.MessageBox.Show("Calculator v1.0\nDeveloped by Adina", "About", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }
    }
}

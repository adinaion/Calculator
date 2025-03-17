using System.Globalization;

namespace Calculator.Services
{
    public class MenuService
    {
        private readonly CalculatorModel _calculatorModel;
        private string _clipboard;
        private bool _isDigitGroupingEnabled = Properties.Settings.Default.isDigitGroupingEnabled;

        public bool IsDigitGroupingEnabled
        {
            get { return _isDigitGroupingEnabled; }
            set
            {
                if (_isDigitGroupingEnabled != value)
                {
                    _isDigitGroupingEnabled = value;
                    Properties.Settings.Default.isDigitGroupingEnabled = _isDigitGroupingEnabled;
                    Properties.Settings.Default.Save();
                    ToggleDigitGrouping();
                }
            }
        }

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
            var cultureInfo = CultureInfo.CurrentCulture;

            string formattedValue;

            if (_isDigitGroupingEnabled)
            {
                formattedValue = value.ToString("N0", cultureInfo);
            }
            else
            {
                formattedValue = value.ToString(CultureInfo.InvariantCulture);
            }

            _calculatorModel.CurrentValue = formattedValue;
        }

        public void About()
        {
            System.Windows.MessageBox.Show("Ion Florina-Adina\n10LF232", "About", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }
    }
}

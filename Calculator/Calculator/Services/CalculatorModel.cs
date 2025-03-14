public class CalculatorModel
{
    public string CurrentValue { get; private set; } = "0";

    private double _previousValue = 0;
    private string _currentOperation = string.Empty;
    private bool _isNewOperation = true;

    public void AppendDigit(string digit)
    {
        if (CurrentValue == "0" || _isNewOperation)
        {
            CurrentValue = digit;
            _isNewOperation = false;
        }
        else
        {
            CurrentValue += digit;
        }
    }

    public void PerformOperation(string operation)
    {
        double operand = double.Parse(CurrentValue);

        if (!string.IsNullOrEmpty(_currentOperation))
        {
            switch (_currentOperation)
            {
                case "+":
                    _previousValue += operand;
                    break;
                case "-":
                    _previousValue -= operand;
                    break;
                case "*":
                    _previousValue *= operand;
                    break;
                case "/":
                    if (operand != 0)
                        _previousValue /= operand;
                    else
                        throw new DivideByZeroException("Cannot divide by zero.");
                    break;
                case "%":
                    if (operand != 0)
                        _previousValue %= operand;
                    else
                        throw new DivideByZeroException("Cannot divide by zero.");
                    break;
                default:
                    throw new InvalidOperationException("Unknown operation.");
            }

            CurrentValue = _previousValue.ToString();
        }
        else
        {
            _previousValue = operand;
        }

        _currentOperation = operation;

        _isNewOperation = true;
    }

    public void CalculateResult()
    {
        if (!string.IsNullOrEmpty(_currentOperation))
        {
            PerformOperation(_currentOperation);
        }

        CurrentValue = _previousValue.ToString();
        _currentOperation = string.Empty;
    }

    public void Clear()
    {
        CurrentValue = "0";
        _previousValue = 0;
        _currentOperation = string.Empty;
        _isNewOperation = true;
    }

    public void ClearLastEntry()
    {
        CurrentValue = "0";
        _isNewOperation = true;
    }

    public void Backspace()
    {
        string newValue = null;
        for (int i = 0; i < CurrentValue.Length - 1; i++)
            newValue += CurrentValue[i];

        CurrentValue = string.IsNullOrEmpty(newValue) ? "0" : newValue;
        _isNewOperation = false;
    }

    public void Inverse()
    {
        double operand = double.Parse(CurrentValue);
        operand = 1.0 / operand;
        CurrentValue = operand.ToString();
    }

    public void Square()
    {
        double operand = double.Parse(CurrentValue);
        operand = operand * operand;
        CurrentValue = operand.ToString();
    }

    public void SquareRoot()
    {
        double operand = double.Parse(CurrentValue);
        operand = Math.Sqrt(operand);
        CurrentValue = operand.ToString();
    }

    public void Negate()
    {
        double operand = double.Parse(CurrentValue);
        operand = -1.0 * operand;
        CurrentValue = operand.ToString();
    }
}

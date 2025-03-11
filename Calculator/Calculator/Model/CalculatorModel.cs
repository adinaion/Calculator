public class CalculatorModel
{
    public string CurrentValue { get; private set; } = "0";

    private double _previousValue = 0;
    private string _currentOperation = string.Empty;

    public void AppendDigit(string digit)
    {
        if (CurrentValue == "0")
        {
            CurrentValue = digit;
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
                default:
                    throw new InvalidOperationException("Unknown operation.");
            }
        }
        else
        {
            _previousValue = operand;
        }

        _currentOperation = operation;

        CurrentValue = "0";
    }

    public void CalculateResult()
    {
        PerformOperation(_currentOperation);

        CurrentValue = _previousValue.ToString();
        _currentOperation = string.Empty;
    }

    public void Clear()
    {
        CurrentValue = "0";
        _previousValue = 0;
        _currentOperation = string.Empty;
    }
}

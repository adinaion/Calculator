public class CalculatorModel
{
    public string CurrentValue { get; private set; } = "0";

    private double _previousValue;

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

    public void PerformOperation(string operation, double operand)
    {
        double currentValue = double.Parse(CurrentValue);

        switch (operation)
        {
            case "+":
                currentValue = _previousValue + operand;
                break;
            case "-":
                currentValue = _previousValue - operand;
                break;
            case "*":
                currentValue = _previousValue * operand;
                break;
            case "/":
                if (operand != 0)
                    currentValue = _previousValue / operand;
                else
                    throw new DivideByZeroException("Cannot divide by zero.");
                break;
            default:
                throw new InvalidOperationException("Unknown operation.");
        }

        _previousValue = currentValue;

        CurrentValue = currentValue.ToString();
    }

    public void Clear()
    {
        CurrentValue = "0";
        _previousValue = 0;
    }

    public void Reset()
    {
        _previousValue = 0;
        CurrentValue = "0";
    }
}

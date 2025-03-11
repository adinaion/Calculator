public class CalculatorModel
{
    public string CurrentValue { get; private set; } = "0";

    private double _previousValue = 0;
    private string _currentOperation = string.Empty; // Operația curentă (ex: "+", "-", etc.)

    public void AppendDigit(string digit)
    {
        if (CurrentValue == "0")
        {
            // Dacă valoarea este 0, începem cu prima cifră
            CurrentValue = digit;
        }
        else
        {
            // Adăugăm cifra la valoarea curentă
            CurrentValue += digit;
        }
    }

    public void PerformOperation(string operation)
    {
        double operand = double.Parse(CurrentValue);

        // Dacă există o operație anterioară, o aplicăm
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
            // Dacă nu există o operație anterioară, setăm valoarea curentă ca valoare de început
            _previousValue = operand;
        }

        // Setăm operația curentă
        _currentOperation = operation;

        // Resetăm valoarea curentă pentru a aștepta un nou operand
        CurrentValue = "0";
    }

    public void CalculateResult()
    {
        double operand = double.Parse(CurrentValue);

        // Aplicăm operația finală
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
                break;
        }

        // Setăm valoarea finală
        CurrentValue = _previousValue.ToString();
        _currentOperation = string.Empty; // Resetăm operația pentru următorul calcul
    }

    public void Clear()
    {
        CurrentValue = "0";
        _previousValue = 0;
        _currentOperation = string.Empty;
    }
}

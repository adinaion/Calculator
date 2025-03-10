public class CalculatorModel
{
    // Folosim string pentru a manipula display-ul, dar convertim la double pentru operațiile matematice
    public string CurrentValue { get; private set; } = "0"; // Schimbăm tipul în string pentru a permite concatenarea cifrelor

    // Metoda pentru adăugarea unei cifre
    public void AppendDigit(string digit)
    {
        if (CurrentValue == "0")
        {
            CurrentValue = digit;  // Dacă valoarea este 0, înlocuim cu cifra apăsată
        }
        else
        {
            CurrentValue += digit;  // Altfel, adăugăm cifra la final
        }
    }

    // Apelată pentru fiecare operație
    public void PerformOperation(string operation, double operand)
    {
        double currentValue = double.Parse(CurrentValue); // Convertim CurrentValue la double pentru a face operațiile matematice

        switch (operation)
        {
            case "+":
                currentValue += operand;
                break;
            case "-":
                currentValue -= operand;
                break;
            case "*":
                currentValue *= operand;
                break;
            case "/":
                if (operand != 0)
                    currentValue /= operand;
                else
                    throw new DivideByZeroException("Cannot divide by zero.");
                break;
            case "%":
                currentValue = currentValue % operand;
                break;
            case "x^2":
                currentValue = Math.Pow(currentValue, 2);
                break;
            case "sqrt":
                if (currentValue < 0)
                    throw new InvalidOperationException("Cannot take the square root of a negative number.");
                currentValue = Math.Sqrt(currentValue);
                break;
            case "+/-":
                currentValue = -currentValue;
                break;
            case "1/x":
                if (currentValue == 0)
                    throw new InvalidOperationException("Cannot divide by zero.");
                currentValue = 1 / currentValue;
                break;
            default:
                throw new InvalidOperationException("Unknown operation.");
        }

        // După efectuarea operației, actualizăm CurrentValue ca string
        CurrentValue = currentValue.ToString();
    }

    // Resetare la zero
    public void Clear()
    {
        CurrentValue = "0";
    }
}

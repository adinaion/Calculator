using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorModel
    {
        public double CurrentValue { get; private set; } = 0;

        // Apelată pentru fiecare operație
        public void PerformOperation(string operation, double operand)
        {
            switch (operation)
            {
                case "+":
                    CurrentValue += operand;
                    break;
                case "-":
                    CurrentValue -= operand;
                    break;
                case "*":
                    CurrentValue *= operand;
                    break;
                case "/":
                    if (operand != 0)
                        CurrentValue /= operand;
                    else
                        throw new DivideByZeroException("Cannot divide by zero.");
                    break;
                case "%":
                    CurrentValue = CurrentValue % operand;
                    break;
                case "x^2":
                    CurrentValue = Math.Pow(CurrentValue, 2);
                    break;
                case "sqrt":
                    if (CurrentValue < 0)
                        throw new InvalidOperationException("Cannot take the square root of a negative number.");
                    CurrentValue = Math.Sqrt(CurrentValue);
                    break;
                case "+/-":
                    CurrentValue = -CurrentValue;
                    break;
                case "1/x":
                    if (CurrentValue == 0)
                        throw new InvalidOperationException("Cannot divide by zero.");
                    CurrentValue = 1 / CurrentValue;
                    break;
                default:
                    throw new InvalidOperationException("Unknown operation.");
            }
        }

        // Resetare la zero
        public void Clear()
        {
            CurrentValue = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public class BaseConverterService
    {
        public string ConvertToBase(int number, int baseValue)
        {
            if (baseValue < 2 || baseValue > 16)
            {
                throw new ArgumentOutOfRangeException("Base must be between 2 and 16.");
            }

            return Convert.ToString(number, baseValue).ToUpper();
        }

        public int ConvertFromBase(string number, int baseValue)
        {
            if (baseValue < 2 || baseValue > 16)
            {
                throw new ArgumentOutOfRangeException("Base must be between 2 and 16.");
            }

            return Convert.ToInt32(number, baseValue);
        }
    }
}

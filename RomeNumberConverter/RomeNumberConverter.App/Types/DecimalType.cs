using System;
using RomeNumberConverter.App.Interfaces;

namespace RomeNumberConverter.App
{
    public class DecimalType : IConverter
    {
        public string Input { get; private set; }
        public DecimalType(string input, IParser parser)
        {
            if (parser.TryParseDecimal(input))
                Input = input.ToUpper().Trim();

            else
                throw new ArgumentException("Argument is not valid");
        }
       
        public string GetResult()
        {
            decimal result;
            if (decimal.TryParse(Input, out result))
                return ConvertToRoman(result);
            else
                return "Argument is not valid";
        }


        private string ConvertToRoman(decimal number)
        {
            if ((number < 0) || (number > 3999)) return "Argument is not valid - Value must be between 1 and 3999";
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ConvertToRoman(number - 1000);
            if (number >= 900) return "CM" + ConvertToRoman(number - 900);
            if (number >= 500) return "D" + ConvertToRoman(number - 500);
            if (number >= 400) return "CD" + ConvertToRoman(number - 400);
            if (number >= 100) return "C" + ConvertToRoman(number - 100);
            if (number >= 90) return "XC" + ConvertToRoman(number - 90);
            if (number >= 50) return "L" + ConvertToRoman(number - 50);
            if (number >= 40) return "XL" + ConvertToRoman(number - 40);
            if (number >= 10) return "X" + ConvertToRoman(number - 10);
            if (number >= 9) return "IX" + ConvertToRoman(number - 9);
            if (number >= 5) return "V" + ConvertToRoman(number - 5);
            if (number >= 4) return "IV" + ConvertToRoman(number - 4);
            if (number >= 1) return "I" + ConvertToRoman(number - 1);
            return "Argument is not valid - Value must be between 1 and 3999";
        }
    }
}

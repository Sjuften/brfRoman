using System;
using RomeNumberConverter.App.Interfaces;

namespace RomeNumberConverter.App
{
    public class DecimalType : IConverter
    {
        public string Input { get; private set; }


        public DecimalType(string input, IParser parser)
        {
            if (!parser.TryParseDecimal(input))
                throw new ArgumentException("Argument is not valid");

            Input = input.ToUpper().Trim();
        }

        public string GetResult()
        {
            decimal result;
            if (decimal.TryParse(Input, out result))
                return ConvertDecimalToRoman(result);
            else
                return "Argument is not valid";
        }


        private string ConvertDecimalToRoman(decimal number)
        {
            if ((number < 0) || (number > 3999)) return "Argument is not valid - Value must be between 1 and 3999";
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ConvertDecimalToRoman(number - 1000);
            if (number >= 900) return "CM" + ConvertDecimalToRoman(number - 900);
            if (number >= 500) return "D" + ConvertDecimalToRoman(number - 500);
            if (number >= 400) return "CD" + ConvertDecimalToRoman(number - 400);
            if (number >= 100) return "C" + ConvertDecimalToRoman(number - 100);
            if (number >= 90) return "XC" + ConvertDecimalToRoman(number - 90);
            if (number >= 50) return "L" + ConvertDecimalToRoman(number - 50);
            if (number >= 40) return "XL" + ConvertDecimalToRoman(number - 40);
            if (number >= 10) return "X" + ConvertDecimalToRoman(number - 10);
            if (number >= 9) return "IX" + ConvertDecimalToRoman(number - 9);
            if (number >= 5) return "V" + ConvertDecimalToRoman(number - 5);
            if (number >= 4) return "IV" + ConvertDecimalToRoman(number - 4);
            if (number >= 1) return "I" + ConvertDecimalToRoman(number - 1);
            return "Argument is not valid - Value must be between 1 and 3999";
        }
    }
}

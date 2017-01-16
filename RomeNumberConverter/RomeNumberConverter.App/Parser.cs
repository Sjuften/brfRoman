using RomeNumberConverter.App.Interfaces;
using System.Linq;
namespace RomeNumberConverter.App
{
    public class Parser : IParser
    {

        public bool TryParseDecimal(string number)
        {
            decimal result;
            if (decimal.TryParse(number, out result))
                return true;

            return false;
        }

        public bool TryParseRoman(string roman)
        {
            var romanLetters = new[] { "I", "V", "X", "L", "C", "D", "M" };
            foreach (var letter in roman.ToUpper())
            {
                if (!romanLetters.Contains(letter.ToString()))
                {
                    return false;
                }
            }

            return true;
        }

    }
}

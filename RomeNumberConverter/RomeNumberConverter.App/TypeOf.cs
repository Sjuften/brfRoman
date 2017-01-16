using RomeNumberConverter.App.Interfaces;
using System.Linq;
namespace RomeNumberConverter.App
{
    public class TypeOf : ITypeOf
    {
        private string[] romanLetters = new[] { "N", "I", "V", "X", "L", "C", "D", "M" };

        public bool IsDecimal(string number)
        {
            decimal result;
            if (decimal.TryParse(number, out result))
                return true;

            return false;
        }

        public bool IsRoman(string roman)
        {
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

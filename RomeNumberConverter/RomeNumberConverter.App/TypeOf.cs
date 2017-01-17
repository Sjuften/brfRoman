using RomeNumberConverter.App.Interfaces;
using System.Linq;
namespace RomeNumberConverter.App
{
    public static class TypeOf
    {
        private static string[] romanLetters = new[] { "N", "I", "V", "X", "L", "C", "D", "M" };

        public static bool IsDecimal(string number)
        {
            decimal result;
            if (decimal.TryParse(number, out result))
                return true;

            return false;
        }

        public static bool IsRoman(string roman)
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

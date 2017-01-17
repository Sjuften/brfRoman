using System.Linq;
namespace RomeNumberConverter.App
{
    public static class TypeOf
    {

        public static bool IsDecimal(string number)
        {
            decimal result;
            if (decimal.TryParse(number, out result))
                return true;

            return false;
        }

        public static bool IsRoman(string roman)
        {
            var romanLetters = new[] { "N", "I", "V", "X", "L", "C", "D", "M" };

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

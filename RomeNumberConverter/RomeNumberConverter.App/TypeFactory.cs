using RomeNumberConverter.App.Interfaces;
using RomeNumberConverter.App.Types;

namespace RomeNumberConverter.App
{
    public static class TypeFactory
    {
        public static IConverter Get(string input, IParser parser)
        {
            return BestMatch(input, parser);
        }

        private static IConverter BestMatch(string input, IParser parser)
        {

            if (parser.TryParseDecimal(input))
                return new DecimalType();

            if (parser.TryParseRoman(input))
                return new RomanType();

            else
                return new NullObjectType();

        }
    }
}

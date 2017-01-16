using RomeNumberConverter.App.Interfaces;
using RomeNumberConverter.App.Types;

namespace RomeNumberConverter.App
{
    public static class TypeFactory
    {
        public static IConverter Get(string input, ITypeOf typeOf)
        {
            return BestMatch(input, typeOf);
        }

        private static IConverter BestMatch(string input, ITypeOf typeOf)
        {

            if (typeOf.IsDecimal(input))
                return new DecimalType(input, typeOf);

            if (typeOf.IsRoman(input))
                return new RomanType(input, typeOf);

            else
                return new NullObjectType(input);

        }
    }
}

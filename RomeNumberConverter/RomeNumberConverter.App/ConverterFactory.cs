using RomeNumberConverter.App.Interfaces;
using RomeNumberConverter.App.Types;
using static RomeNumberConverter.App.Enums.ConverterTypes;

namespace RomeNumberConverter.App
{
    public static class ConverterFactory
    {
        public static IConverter Get(string input, Converters converter)
        {
            return Converter(input, converter);
        }

        private static IConverter Converter(string input, Converters converter)
        {

            if (converter == Converters.RomanDecimal)
                return new RomanDecimalConveter(input);

            else
                return new NullObjectConverter(input);

        }
    }
}

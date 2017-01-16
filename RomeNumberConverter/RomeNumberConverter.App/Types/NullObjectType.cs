using RomeNumberConverter.App.Interfaces;

namespace RomeNumberConverter.App.Types
{
    public class NullObjectType : IConverter
    {
        public string Input { get; private set; }
        public NullObjectType(string input)
        {
            Input = input.Trim();
        }

        public string GetConvertionResult()
        {
            return $"{Input} Is not a valid argument";
        }
    }
}

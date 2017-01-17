using RomeNumberConverter.App.Interfaces;

namespace RomeNumberConverter.App.Types
{
    public class NullObjectConverter : IConverter
    {
        public string Input { get; private set; }
        public NullObjectConverter(string input)
        {
            Input = input.Trim();
        }
        public string GetResult() => string.Format($"{Input} is not a valid argument");
    }
}

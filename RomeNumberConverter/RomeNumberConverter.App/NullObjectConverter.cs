using RomeNumberConverter.App.Interfaces;

namespace RomeNumberConverter.App.Types
{
    public class NullObjectConverter : IConverter
    {
        private string _input;
        public NullObjectConverter(string input)
        {
           _input = input;
        }
        public string GetResult() => string.Format($"This converter has not yet been initialized");
    }
}

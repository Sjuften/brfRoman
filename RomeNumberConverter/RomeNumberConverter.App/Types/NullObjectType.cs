using RomeNumberConverter.App.Interfaces;

namespace RomeNumberConverter.App.Types
{
    public class NullObjectType : IConverter
    {
        public string Convert(string input)
        {
            return "Is not a valid argument";
        }
    }
}

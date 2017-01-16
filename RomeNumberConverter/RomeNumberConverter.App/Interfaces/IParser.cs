namespace RomeNumberConverter.App.Interfaces
{
    public interface IParser
    {
        bool TryParseDecimal(string input);
        bool TryParseRoman(string input);
    }
}

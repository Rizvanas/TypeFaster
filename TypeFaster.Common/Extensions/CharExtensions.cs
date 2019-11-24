
namespace TypeFaster.Common.Extensions
{
    public static class CharExtensions
    {
        public static bool IsLetterDigitSymbolOrWhiteSpace(this char character)
        {
            return char.IsLetterOrDigit(character) ||
                   char.IsSymbol(character) ||
                   char.IsWhiteSpace(character) ||
                   char.IsPunctuation(character);
        }
    }
}

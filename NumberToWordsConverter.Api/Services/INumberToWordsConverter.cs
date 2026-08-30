namespace NumberToWordsConverter.Api.Services;

public interface INumberToWordsConverter
{
    /// <summary>
    /// Converts a numeric dollar amount to uppercase words.
    /// </summary>
    /// <param name="amount">
    /// The dollar amount to convert. The whole-dollar and fractional parts must be
    /// separated by a period; a one-digit fractional part is treated as tenths of a dollar.
    /// </param>
    /// <returns>
    /// The amount formatted as words, using the pattern
    /// <c>[dollars] DOLLARS AND [cents] CENTS</c>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="amount"/> is not a valid numeric value.
    /// </exception>
    public string ConvertToWords(string amount);
}

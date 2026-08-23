using NumberToWordsConverter.Api.Services;
using Xunit;

namespace NumberToWordsConverter.Tests;

public class NumberToWordsConverterTests
{
    private readonly INumberToWordsConverter _converter;

    public NumberToWordsConverterTests()
    {
        _converter = new Api.Services.NumberToWordsConverter();
    }

    [Theory]
    [InlineData("0", "ZERO DOLLARS AND ZERO CENTS")]
    [InlineData("5", "FIVE DOLLARS AND ZERO CENTS")]
    [InlineData("14", "Fourteen DOLLARS AND ZERO CENTS")]
    [InlineData("42", "FORTY TWO DOLLARS AND ZERO CENTS")]
    [InlineData("123", "ONE HUNDRED AND TWENTY THREE DOLLARS AND ZERO CENTS")]
    public void ConvertToWords_ValidAmounts_ReturnsExpectedWords(string amount, string expected)
    {
        var result = _converter.ConvertToWords(amount);

        Assert.Equal(expected, result, ignoreCase: true);
    }
}

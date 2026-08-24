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
    [InlineData("14", "FOURTEEN DOLLARS AND ZERO CENTS")]
    [InlineData("20", "TWENTY DOLLARS AND ZERO CENTS")]
    [InlineData("42", "FORTY-TWO DOLLARS AND ZERO CENTS")]
    [InlineData("123", "ONE HUNDRED AND TWENTY-THREE DOLLARS AND ZERO CENTS")]
    [InlineData("123.45", "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS")]
    [InlineData("133.50", "ONE HUNDRED AND THIRTY-THREE DOLLARS AND FIFTY CENTS")]
    [InlineData("10.456", "TEN DOLLARS AND FORTY-FIVE CENTS")]
    [InlineData("143.3", "ONE HUNDRED AND FORTY-THREE DOLLARS AND THIRTY CENTS")]
    [InlineData("1234", "ONE THOUSAND TWO HUNDRED AND THIRTY-FOUR DOLLARS AND ZERO CENTS")]
    public void ConvertToWords_ValidAmounts_ReturnsExpectedWords(string amount, string expected)
    {
        //act
        var result = _converter.ConvertToWords(amount);

        //assert
        Assert.Equal(expected, result, ignoreCase: true);
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("123.sfg")]
    [InlineData("llv.223")]
    public void InvalidAmountsThrowsArgumentException(string amount)
    {
        //act
        var exception = Assert.Throws<ArgumentException>(() => _converter.ConvertToWords(amount));

        //assert
        Assert.Equal("Amount must be a valid numeric value. (Parameter 'amount')", exception.Message);
    }
}

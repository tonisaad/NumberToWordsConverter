namespace NumberToWordsConverter.Api.Services;

public interface INumberToWordsConverter
{
    public string ConvertToWords(string amount);
}
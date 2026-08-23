namespace NumberToWordsConverter.Api.Services;

public class NumberToWordsConverter : INumberToWordsConverter
{
    private static readonly string[] Ones = {
        "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE",
        "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN",
        "SEVENTEEN", "EIGHTEEN", "NINETEEN"
    };
    private static readonly string[] Tens = {
        "", "", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
    };
    
    public string ConvertToWords(string amount)
    {
        if (amount == "0")
        {
            return "ZERO DOLLARS AND ZERO CENTS";
        }

        int dollars = int.Parse(amount);
        string dollarWords = ConvertThreeDigits(dollars);

        return $"{dollarWords} DOLLARS AND ZERO CENTS";
    }

    private string ConvertTwoDigits(int number)
    {
        if (number < 20)
        {
            return Ones[number];
        }
        int tensDigit = number / 10;
        int digit = number % 10;
        return $"{Tens[tensDigit]} {Ones[digit]}";
    }
    
    private string ConvertThreeDigits(int number)
    {
        if (number < 100)
        {
            return ConvertTwoDigits(number);
        }
        int hundredsDigit = number / 100;
        int remainder = number % 100;
        string hundredsWords = $"{Ones[hundredsDigit]} HUNDRED";
        return remainder == 0 ? hundredsWords : $"{hundredsWords} AND {ConvertTwoDigits(remainder)}";
    }
}
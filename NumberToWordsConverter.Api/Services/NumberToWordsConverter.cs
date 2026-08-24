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
    
    private static readonly string[] ScaleWords = { "", "THOUSAND", "MILLION", "BILLION" };
    
    public string ConvertToWords(string amount)
    {
        if (amount == "0")
        {
            return "ZERO DOLLARS AND ZERO CENTS";
        }
        
        var parts = amount.Split('.');
        var dollars = int.Parse(parts[0]);
        var cents = 0;
        if (parts.Length > 1)
        {
            string centsPart = parts[1];
            if (centsPart.Length == 1)
            {
                centsPart += "0";
            }
            else if (centsPart.Length > 2)
            {
                centsPart = centsPart.Substring(0, 2);
            }
            cents = int.Parse(centsPart);
        }
        
        var dollarWords = ConvertWholeNumber(dollars);
        var centsWords = ConvertTwoDigits(cents);

        return $"{dollarWords} DOLLARS AND {centsWords} CENTS";
    }

    private string ConvertTwoDigits(int number)
    {
        if (number < 20)
        {
            return Ones[number];
        }
        var tensDigit = number / 10;
        var digit = number % 10;
        return digit == 0 ? Tens[tensDigit] : $"{Tens[tensDigit]}-{Ones[digit]}";
    }
    
    private string ConvertThreeDigits(int number)
    {
        if (number < 100)
        {
            return ConvertTwoDigits(number);
        }
        var hundredsDigit = number / 100;
        var remainder = number % 100;
        string hundredsWords = $"{Ones[hundredsDigit]} HUNDRED";
        return remainder == 0 ? hundredsWords : $"{hundredsWords} AND {ConvertTwoDigits(remainder)}";
    }
    
    private string ConvertWholeNumber(int number)
    {
        if (number == 0)
        {
            return "ZERO";
        }

        var groups = new List<string>();
        var scaleIndex = 0;

        while (number > 0)
        {
            var chunk = number % 1000;
            if (chunk != 0)
            {
                var chunkWords = ConvertThreeDigits(chunk);
                if (scaleIndex > 0)
                {
                    chunkWords += $" {ScaleWords[scaleIndex]}";
                }
                groups.Insert(0, chunkWords);
            }
            number /= 1000;
            scaleIndex++;
        }

        return string.Join(" ", groups);
    }
}
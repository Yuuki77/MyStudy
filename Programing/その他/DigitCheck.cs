public class DigitCheck
{
	private static bool isCapitalCaseAlphabetic(char anyChar)
	{
		var number = anyChar - 'A';
		return number >= 0 && number < 26;
	}

	private static bool isLowerCaseAlphabetic(char anyChar)
	{
		var number = anyChar - 'a';
		return number >= 0 && number < 26;
	}

	private static bool isDigit(char anyChar)
	{
		var number = anyChar - '0';
		return number >= 0 && number <= 9;
	}
}
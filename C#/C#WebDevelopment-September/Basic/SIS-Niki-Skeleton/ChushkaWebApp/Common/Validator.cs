namespace ChushkaWebApp.Common
{

	using System.Collections.Generic;
	using System.Text.RegularExpressions;

	public static class Validator
	{
		public static bool DoesMatchPattern(string text, string pattern)
		{
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			if (Regex.IsMatch(text, pattern))
			{
				return true;
			}

			return false;
		}

		public static bool IfContainsSymbol(string text, char symbol)
		{
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			if (text.Contains(symbol))
			{
				return true;
			}

			return false;
		}

		public static bool AreTheSame(string first, string second)
		{
			if (string.IsNullOrEmpty(first))
			{
				return false;
			}
			if (string.IsNullOrEmpty(second))
			{
				return false;
			}
			if (first == second)
			{
				return true;
			}

			return false;
		}

		public static bool IsLongerOrEqualThen(int parameter, int length)
		{
			if (parameter >= length)
			{
				return true;
			}

			return false;
		}
		public static bool HasLengthBetween(string text, int min, int max)
		{
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			if (text.Length >= min && text.Length<= max)
			{
				return true;
			}

			return false;
		}
		public static bool HasFirstLetterUppercase(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			if (char.IsUpper(text[0]))
			{
				return true;
			}

			return false;
		}

		public static bool StartsWithFromList(string text, IList<string> permittedItems)
		{

			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			foreach (var permittedItem in permittedItems)
			{
				if (text.StartsWith(permittedItem))
				{
					return true;
				}
			}

			return false;
		}
		public static bool IsPositive(decimal number)
		{
			if (number >= 0)
			{
				return true;
			}

			return false;
		}
	}
}

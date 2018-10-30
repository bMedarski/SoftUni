namespace GameStore.Common
{
	using System.Collections.Generic;

	public static class Constants
	{
		public const string CookieAuthKey = ".auth-game-store";
		public const int CookieExpirationDays = 7;
		public const string NoSuchIdMessage = "There si no such Id";
		public const string WrongUserNameOrPassword = "Wrong username or password, please try again";
		public const string DateFormatPattern = "d";

		public const string LoginValidationNamePattern = "^[a-zA-Z -.]+$";
		public static string LoginValidationPasswordPattern = $"(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])."+"{"+ MinimumPasswordLength + ",}";

		public const int MinimumPasswordLength = 6;
		public const int MinimumPasswordLowercaseLetters = 1;
		public const int MinimumPasswordUppercaseLetters = 1;
		public const int MinimumPasswordDigits = 1;
		public const char EmailRequiredCharacter = '@';


		public const int MinimumGameTitleLength = 3;
		public const int MaximumGameTitleLength = 100;
		public const int TrailerLength = 11;
		public const int MinimumDescriptionLength = 20;
		public static IList<string> ThumbnailPermittedPrefixes = new List<string>() {"http://", "https://","null"};
		public const string TrailerValidationPattern = "https:\\/\\/www\\.youtube\\.com\\/watch\\?v=[\\w+]{11}";

		public static string InvalidPasswordMessage =
			$"Invalid Password. It should be at least {MinimumPasswordLength} symbols long, containing {MinimumPasswordUppercaseLetters} uppercase letter, {MinimumPasswordLowercaseLetters} lowercase letter and {MinimumPasswordDigits} digit!";
		public static string InvalidFullNameMessage = "Invalid Full Name. It should be containing only letters digits or intervals";
		public static string InvalidEmailMessage = $"Invalid Email. It should be containing {EmailRequiredCharacter}";
		public static string InvalidRepeatPasswordMessage = "Invalid Password. The password and confirm password must be the same";
		public static string DuplicateUserIdMessage = "This username/email is already in use. Try another.";

		public static string InvalidGameTitleMessage =
			$"The game title must start with Uppercase letter and has length between {MinimumGameTitleLength} and {MaximumGameTitleLength}";

		public static string InvalidGameTrailerLengthMessage =
			$"The game trailer must be a video from youtube and trailer Id must be exactly {TrailerLength} characters long";

		public static string InvalidSizeMessage = "The game size must be a positive number";
		public static string InvalidPriceMessage = "The game price must be a positive number";

		public static string InvalidGameDescriptionLengthMessage =
			$"The game description must be at least {MinimumDescriptionLength} characters long";

		public static string InvalidThumbnailMessage =
			$"The thumbnail must start with one of the following: {string.Join(',', ThumbnailPermittedPrefixes)}";

		public static string DuplicateGameInShoppingCart = "Game already bought or in shopping cart";
	}
}

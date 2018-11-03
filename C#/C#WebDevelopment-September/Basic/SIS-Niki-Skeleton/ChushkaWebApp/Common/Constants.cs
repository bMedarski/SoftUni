namespace ChushkaWebApp.Common
{

	public static class Constants
	{
		public const string CookieAuthKey = ".auth-cakes";
		public const int CookieExpirationDays = 7;
		public const string NoSuchIdMessage = "There si no such Id";
		public const string WrongUserNameOrPassword = "Wrong username or password, please try again";
		public const string DateFormatPattern = "d";
		public const char EmailRequiredCharacter = '@';
	
		public static string InvalidEmailMessage = $"Invalid Email. It should be containing {EmailRequiredCharacter}";
		public static string InvalidRepeatPasswordMessage = "Invalid Password. The password and confirm password must be the same";
		public static string DuplicateUserIdMessage = "This username/email is already in use. Try another.";
	}
}

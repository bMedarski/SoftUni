namespace TorshiaWebApp.Common
{
	public static class Constants
	{
		public const string CookieAuthKey = ".auth-cakes";
		public const int CookieExpirationDays = 7;
		public static string DuplicateUserIdMessage = "This username is already in use. Try another.";
		public const char EmailRequiredCharacter = '@';
		public static string InvalidRepeatPasswordMessage = "Invalid Password. The password and confirm password must be the same";
		public static string InvalidEmailMessage = $"Invalid Email. It should be containing {EmailRequiredCharacter}";
		public const string NoSuchIdMessage = "There si no such Id";
		public const string WrongUserNameOrPassword = "Wrong username or password, please try again";
	}
}

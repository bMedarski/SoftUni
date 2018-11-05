namespace PandaWebApp.Common
{
	public static class Constants
	{
		public const string CookieAuthKey = ".auth-cakes";
		public const int CookieExpirationDays = 7;
		public const string NoSuchIdMessage = "There si no such Id";
		public const string NoSuchUserName = "There is no user with this name";
		public const string NoSuchPackageId = "There is no package with this id";
		public const string WrongUserNameOrPassword = "Wrong username or password, please try again";
		public const string DateFormatPattern = "d";
		public const char EmailRequiredCharacter = '@';
	
		public static string InvalidEmailMessage = $"Invalid Email. It should be containing {EmailRequiredCharacter}";
		public static string InvalidConfirmPasswordMessage = "Invalid Password. The password and confirm password must be the same";
		public static string DuplicateUserIdMessage = "This username is already in use. Please try another!";
		public static string InvalidAcquiredMessage = "This package does not belong to you account";
		public static string DefaultAdminUserName = "Admin";
		public static string DefaultPackageStatus = "Pending";

		public static string PackageStatusDelivered = "Delivered";
		public static string PackageStatusShipped = "Shipped";
		public static string PackageStatusAcquired = "Acquired";
		public static string PackageStatusPending = DefaultPackageStatus;

		public static double FeeTax = 2.67;
		public static string PackageStatusPendingDateMessage = "N/A";
		public static string PackageStatusDeliveredOrAcquiredDateMessage = "Delivered";
	}
}

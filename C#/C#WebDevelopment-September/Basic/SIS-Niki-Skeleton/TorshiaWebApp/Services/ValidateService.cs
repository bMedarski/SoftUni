namespace TorshiaWebApp.Services
{
	using Common;
	using ViewModels.Users;

	public class ValidateService
	{
		public string ValidateUser(RegisterViewModel model)
		{
			if (!Validator.IfContainsSymbol(model.Email, Constants.EmailRequiredCharacter))
			{
				return Constants.InvalidEmailMessage;
			}


			if (!Validator.AreTheSame(model.Password, model.ConfirmPassword))
			{
				return Constants.InvalidRepeatPasswordMessage;
			}

			return "";
		}
	}
}

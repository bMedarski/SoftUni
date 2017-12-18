namespace PhotoShare.Client.Core.Contracts
{
    public interface ICommand
    {
	    string Execute(params string[] data);
    }
}

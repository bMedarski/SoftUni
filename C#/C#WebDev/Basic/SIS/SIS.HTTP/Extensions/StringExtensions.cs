namespace SIS.HTTP.Extensions
{
	public static class StringExtensions
    {
	    public static string Capitalize(this string word)
	    {
		    var fisrtLetter = word[0].ToString().ToUpper();
		    var capitalized = fisrtLetter + word.Substring(1);
		    return capitalized;
	    }
    }
}

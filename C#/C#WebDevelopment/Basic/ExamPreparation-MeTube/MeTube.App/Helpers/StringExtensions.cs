namespace MeTube.App.Helpers
{
    public static class StringExtensions
    {
        public static string Shortify(this string input, int length)
        {
            if (input == null)
            {
                return input;
            }

            var result = input.Length > length ? $"{input.Substring(0, length)}..." : input;
            return result;
        }

        public static string CapitalizeFirstLetter(this string param)
        {
            return param[0].ToString().ToUpper() + param.Substring(1);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameWork.Helpers
{
    public static class StringExtensions
    {
	    public static string Capitalize(this string input)
	    {
		    if (input == null || input.Length == 0)
		    {
			    return input;
		    }

		    var firstLetter = char.ToUpper(input.First());
		    var rest = input.Substring(1);

		    return $"{firstLetter}{rest}";
	    }
	}
}

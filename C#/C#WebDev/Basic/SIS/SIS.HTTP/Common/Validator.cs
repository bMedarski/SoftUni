using System;
namespace SIS.HTTP.Common
{
	using System;

	public class Validator
	{
		public static void ThrowIfNull(object obj, string name)
		{
			if (obj == null)
			{
				throw new ArgumentNullException(name);
			}
		}

		public static void ThrowIfNullOrEmpty(string parameter,string name)
		{
			if (string.IsNullOrEmpty(parameter))
			{
				throw new ArgumentException($"{name} cannot be null or empty.", name);
			}
		}
	}
}

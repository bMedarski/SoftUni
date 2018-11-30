namespace Eventures.WebApp.Utilities
{
	using Contracts;

	public class Counter : ICounter
	{
		private int count = 0;

		public int Next()
		{
			return ++this.count;
		}

		public int Current() => this.count;
	}
}

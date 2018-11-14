using System.Collections.Generic;

namespace Panda.ViewModels.Home
{
	using Packages;

	public class HomeViewModel
	{
		public IEnumerable<PackageViewModel> PendingPackages { get; set; }
		public IEnumerable<PackageViewModel> ShippedPackages { get; set; }
		public IEnumerable<PackageViewModel> DeliveredPackages { get; set; }
	}
}

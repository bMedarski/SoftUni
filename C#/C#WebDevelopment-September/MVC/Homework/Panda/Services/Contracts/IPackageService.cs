namespace Panda.Services.Contracts
{
	using System.Collections.Generic;
	using ViewModels.Packages;

	public interface IPackageService
	{
		void CreatePackage(CreatePackageBindingModel model);
		IList<PackageViewModel> GetAllPackagesByStatus(string status, string username);
		PackageDetailsViewModel GetPackage(int id);
		IList<DetailedPackagesListViewModel> GetAllShippedPackages();
		IList<DetailedPackagesListViewModel> GetAllDeliveredPackages();
		IList<DetailedPackagesListViewModel> GetAllPendingPackages();
		void Ship(int id);
		void Deliver(int id);
		void Acquire(int id, string username);
	}
}

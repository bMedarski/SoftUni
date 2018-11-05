namespace PandaWebApp.Services
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using Common;
	using Contracts;
	using Microsoft.EntityFrameworkCore;
	using Models.BindingModels.Packages;
	using Models.ViewModels.Packages;
	using PandaDatabase;
	using PandaModel;

	public class PackagesService:IPackagesService
	{
		private PandaDbContext Db { get; }

		public PackagesService(PandaDbContext db)
		{
			this.Db = db;
		}

		public void CreatePackage(CreatePackageBindingModel model)
		{
			var user = this.Db.Users.FirstOrDefault(u => u.Username == model.Recipient);
			var status = this.Db.Statuses.FirstOrDefault(s => s.Name == Constants.DefaultPackageStatus);
			var package = new Package
			{
				Recipient = user,
				Description = model.Description,
				ShippingAddress = model.ShippingAddress,
				Weight = model.Weight,
				Status = status
			};

			this.Db.Packages.Add(package);
			this.Db.SaveChanges();
		}

		public PackageDetailsViewModel GetPackage(int id)
		{
			var package = this.Db.Packages.Include(p=>p.Status).Include(p=>p.Recipient).FirstOrDefault(p => p.Id == id);
			if (package == null)
			{
				return null;
			}
			var packageModel = new PackageDetailsViewModel();
			packageModel.Description = package.Description;
			packageModel.ShippingAddress = package.ShippingAddress;
			packageModel.Status = package.Status.Name;
			packageModel.Weight = package.Weight;
			packageModel.Recipient = package.Recipient.Username;
			if (packageModel.Status == Constants.PackageStatusPending)
			{
				packageModel.DeliveryDate = Constants.PackageStatusPendingDateMessage;
			}
			else if (packageModel.Status == Constants.PackageStatusShipped)
			{
				packageModel.DeliveryDate = package.DeliveryDate?.ToString(Constants.DateFormatPattern,CultureInfo.InvariantCulture);
			}
			else
			{
				packageModel.DeliveryDate = Constants.PackageStatusDeliveredOrAcquiredDateMessage;
			}

			return packageModel;
		}

		public void Ship(int id)
		{
			var package = this.Db.Packages.Where(p => p.Id == id).FirstOrDefault();
			var status = this.Db.Statuses.FirstOrDefault(s => s.Name == Constants.PackageStatusShipped);
			package.Status = status;
			Random rnd = new Random();
			var daysToAdd = rnd.Next(20, 41);
			package.DeliveryDate = DateTime.UtcNow.AddDays(daysToAdd);
			this.Db.SaveChanges();
		}
		public void Deliver(int id)
		{
			var package = this.Db.Packages.Where(p => p.Id == id).FirstOrDefault();
			var status = this.Db.Statuses.FirstOrDefault(s => s.Name == Constants.PackageStatusDelivered);
			package.Status = status;
			this.Db.SaveChanges();
		}
		public void Acquire(int id,string username)
		{
			var package = this.Db.Packages.Where(p => p.Id == id).FirstOrDefault();
			var status = this.Db.Statuses.FirstOrDefault(s => s.Name == Constants.PackageStatusAcquired);
			var receipt = new Receipt();
			var user = this.Db.Users.Where(u => u.Username == username).FirstOrDefault();
			receipt.Recipient = user;
			receipt.IssuedOn = DateTime.UtcNow;
			receipt.Package = package;
			receipt.Fee = (decimal)(package.Weight * Constants.FeeTax);
			this.Db.Receipts.Add(receipt);
			this.Db.SaveChanges();
		}
		public IList<DetailedPackagesListViewModel> GetAllPendingPackages()
		{
			var currentStatus = this.Db.Statuses.FirstOrDefault(s => s.Name == Constants.PackageStatusPending);
			return this.Db.Packages
				.Include(p => p.Status)
				.Include(p => p.Recipient)
				.Where(p => p.Status == currentStatus).Select(p => new DetailedPackagesListViewModel
				{
					Description = p.Description,
					Weight = p.Weight,
					ShippingAddress = p.ShippingAddress,
					Id = p.Id,
					Recipient = p.Recipient.Username,
				}).ToList();
		}
		public IList<DetailedPackagesListViewModel> GetAllDeliveredPackages()
		{
			var currentStatus = this.Db.Statuses.FirstOrDefault(s => s.Name == Constants.PackageStatusDelivered||s.Name==Constants.PackageStatusAcquired);
			return this.Db.Packages
				.Include(p => p.Status)
				.Include(p => p.Recipient)
				.Where(p => p.Status == currentStatus).Select(p => new DetailedPackagesListViewModel
				{
					Description = p.Description,
					Weight = p.Weight,
					ShippingAddress = p.ShippingAddress,
					Id = p.Id,
					Recipient = p.Recipient.Username,
				}).ToList();
		}
		public IList<DetailedPackagesListViewModel> GetAllShippedPackages()
		{
			var currentStatus = this.Db.Statuses.FirstOrDefault(s => s.Name == Constants.PackageStatusShipped);
			return this.Db.Packages
				.Include(p => p.Status)
				.Include(p => p.Recipient)
				.Where(p => p.Status == currentStatus).Select(p => new DetailedPackagesListViewModel
				{
					Description = p.Description,
					Weight = p.Weight,
					DeliveryDate = p.DeliveryDate,
					Id = p.Id,
					Recipient = p.Recipient.Username,
				}).ToList();
		}
		public IList<PackageViewModel> GetAllPackagesByStatus(string status,string username)
		{
			var currentStatus = this.Db.Statuses.FirstOrDefault(s => s.Name == status);
			if (username == "Admin")
			{
				return this.Db.Packages
					.Where(p => p.Status == currentStatus)
					.Select(p => new PackageViewModel
					{
						Id = p.Id,
						Name = p.Description,
					})
					.ToList();
			}
			else
			{
				var user = this.Db.Users.FirstOrDefault(u => u.Username == username);
				return this.Db.Packages
					.Where(p => p.Status == currentStatus&&p.Recipient==user)
					.Select(p => new PackageViewModel
					{
						Id = p.Id,
						Name = p.Description,
					})
					.ToList();
			}
		}
	}
}

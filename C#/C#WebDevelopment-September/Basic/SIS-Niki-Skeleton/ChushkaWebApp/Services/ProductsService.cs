namespace ChushkaWebApp.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using ChushkaData;
	using ChushkaModels;
	using Controllers;
	using ViewModels.Products;

	public class ProductsService:BaseController
	{
		public ProductsService(ChushkaDb db)
		:base(db)
		{
			//this.Db = db;
		}
	
		//private ChushkaDb Db { get; set; }

		internal IList<ProductsHomeViewModel> GetAllProducts()
		{
			return this.Db.Products.Select(p => new ProductsHomeViewModel
			{
				Id = p.Id,
				Name = p.Name,
				Description = p.Description,
				Price = p.Price,
			}).ToList();
		}

		internal ProductViewModel GetProduct(int id)
		{
			return this.Db.Products.Where(p => p.Id == id).Select(p => new ProductViewModel
			{
				Id = p.Id,
				Name = p.Name,
				Description = p.Description,
				Price = p.Price,
				Type = p.ProductType.Name,

			}).FirstOrDefault();
		}

		internal void CreateProduct(ProductCreateViewModel model)
		{
			var productType = this.Db.ProductTypes.Where(pt => pt.Name == model.Type).FirstOrDefault();

			var product = new Product
			{
				Name = model.Name,
				Description = model.Description,
				ProductType = productType,
				Price = model.Price
			};
			this.Db.Products.Add(product);
			this.Db.SaveChanges();
		}

		internal void EditProduct(ProductViewModel model)
		{
			var product = this.Db.Products.FirstOrDefault(p => p.Id == model.Id);
			var type = this.Db.ProductTypes.FirstOrDefault(pt => pt.Name == model.Type);
			product.ProductType = type;
			product.Description = model.Description;
			product.Name = model.Name;
			product.Price = model.Price;

			this.Db.SaveChanges();
		}
		internal void DeleteProduct(int id)
		{
			var product = this.Db.Products.FirstOrDefault(p => p.Id == id);
			this.Db.Products.Remove(product);
			this.Db.SaveChanges();
		}

		internal void OrderProduct(int id,string username)
		{
			var product = this.Db.Products.FirstOrDefault(p => p.Id == id);
			var user = this.Db.Users.FirstOrDefault(u => u.Username == username);
			var order = new Order
			{
				Client = user,
				Product = product,
				OrderedOn = DateTime.UtcNow,
			};

			this.Db.Orders.Add(order);
			this.Db.SaveChanges();
		}
	}
}

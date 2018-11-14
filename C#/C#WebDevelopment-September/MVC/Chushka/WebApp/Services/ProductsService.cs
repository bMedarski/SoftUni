namespace WebApp.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security.Claims;
	using System.Security.Principal;
	using Contracts;
	using Data;
	using global::Models;
	using global::Models.Enums;
	using Microsoft.AspNetCore.Identity;
	using ViewModels.Home;
	using ViewModels.Products;

	public class ProductsService:IProductsService
	{
		public ChushkaDbContext DbContext { get; set; }
		private SignInManager<ChushkaUser> SignInManager { get; }

		public ProductsService(ChushkaDbContext dbContext,SignInManager<ChushkaUser> signInManager)
		{
			this.SignInManager = signInManager;
			this.DbContext = dbContext;
			this.SeedProducts();
		}

		public Product Create(ProductViewModel model)
		{
			Product product = new Product()
			{
				Name = model.Name,
				Description = model.Description,
				Price = model.Price,
				ProductType = (ProductType)Enum.Parse(typeof(ProductType), model.Type)
			};
			this.DbContext.Products.Add(product);
			this.DbContext.SaveChanges();
			return product;
		}

		public IList<HomeProductViewModel> GetAllProducts()
		{
			return this.GetProducts().Select(p => new HomeProductViewModel()
			{
				Name = p.Name,
				Description = p.Description,
				Price = p.Price,
				Id = p.Id,
			}).ToList();
		}

		public ProductDetailsViewModel GetProductDetails(int id)
		{
			var product = this.GetProductById(id);
			return new ProductDetailsViewModel()
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				Type = product.ProductType.ToString(),
			};
		}

		public void Edit(ProductViewModel model)
		{
			var product = this.GetProductById(model.Id);
			product.Price = model.Price;
			product.Description = model.Description;
			product.Name = model.Name;
			product.ProductType = (ProductType) Enum.Parse(typeof(ProductType), model.Type);
			this.DbContext.SaveChanges();
		}

		public void Delete(ProductViewModel model)
		{
			var product = this.GetProductById(model.Id);
			this.DbContext.Products.Remove(product);
			this.DbContext.SaveChanges();
		}

		public ProductViewModel GetProductViewModel(int id)
		{
			var product = this.GetProductById(id);
			return new ProductViewModel()
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				Type = product.ProductType.ToString(),
			};
		}
		private IList<Product> GetProducts()
		{
			return this.DbContext.Products.ToList();
		}

		private Product GetProductByName(string name)
		{
			return this.DbContext.Products.FirstOrDefault(p => p.Name == name);
		}
		private Product GetProductById(int  id)
		{
			return this.DbContext.Products.FirstOrDefault(p => p.Id == id);
		}

		public void Order(int id,ClaimsPrincipal userPrincipal)
		{
			var product = this.GetProductById(id);
			var user = this.SignInManager.UserManager.GetUserAsync(userPrincipal).Result;
			var order = new Order {Client = user, Product = product, OrderedOn = DateTime.UtcNow};
			this.DbContext.Orders.Add(order);
			this.DbContext.SaveChanges();
		}
		private void SeedProducts()
		{
			IList<Product> products = new List<Product>()
			{
				new Product() {Name = "Banana", Price = 2.2m, ProductType = ProductType.Food, Description = "A banana is an edible fruit – botanically a berry[1][2] – produced by several kinds of large herbaceous flowering plants in the genus Musa.[3] In some countries, bananas used for cooking may be called \"plantains\", distinguishing them from dessert bananas. The fruit is variable in size, color, and firmness, but is usually elongated and curved, with soft flesh rich in starch covered with a rind, which may be green, yellow, red, purple, or brown when ripe. The fruits grow in clusters hanging from the top of the plant. Almost all modern edible seedless (parthenocarp) bananas come from two wild species – Musa acuminata and Musa balbisiana. The scientific names of most cultivated bananas are Musa acuminata, Musa balbisiana, and Musa × paradisiaca for the hybrid Musa acuminata × M. balbisiana, depending on their genomic constitution. The old scientific name Musa sapientum is no longer used."},
				new Product() {Name = "Chocolate", Price = 9.2m, ProductType = ProductType.Food, Description = "Chocolate is a typically sweet, usually brown, food preparation of roasted and ground cacao seeds. It is made in the form of a liquid, paste, or in a block, or used as a flavoring ingredient in other foods. The earliest evidence of use traces to the Olmecs (Mexico), with evidence of chocolate beverages dating to 1900 BC.[1][2] The majority of Mesoamerican people made chocolate beverages, including the Maya and Aztecs."},
				new Product() {Name = "Milk", Price = 2.2m, ProductType = ProductType.Food, Description = "Milk is a nutrient-rich, white liquid food produced by the mammary glands of mammals. It is the primary source of nutrition for infant mammals (including humans who are breastfed) before they are able to digest other types of food. Early-lactation milk contains colostrum, which carries the mother's antibodies to its young and can reduce the risk of many diseases. It contains many other nutrients[1] including protein and lactose. Interspecies consumption of milk is not uncommon, particularly among humans, many of whom consume the milk of other mammals.["},
				new Product() {Name = "Tomato", Price = 2.2m, ProductType = ProductType.Food, Description = "The tomato (see pronunciation) is the edible, often red, berry of the nightshade Solanum lycopersicum,[2][1] commonly known as a tomato plant. The species originated in western South America.[2][3] The Nahuatl (Aztec language) word tomatl gave rise to the Spanish word tomate, from which the English word tomato derived.[3][4] Its use as a cultivated food may have originated with the indigenous peoples of Mexico.[2][5] The Spanish discovered the tomato from their contact with the Aztec during the Spanish colonization of the Americas and brought it to Europe. From there, the tomato was introduced to other parts of the European-colonized world during the 16th century."},
				new Product() {Name = "Potato", Price = 2.2m, ProductType = ProductType.Food, Description = "The potato is a starchy, tuberous crop from the perennial nightshade Solanum tuberosum. In many contexts, potato refers to the edible tuber, but it can also refer to the plant itself.[2] Common or slang terms include tater and spud. Potatoes were introduced to Europe in the second half of the 16th century by the Spanish. Today they are a staple food in many parts of the world and an integral part of much of the world's food supply. As of 2014, potatoes were the world's fourth-largest food crop after maize (corn), wheat, and rice."},
				new Product() {Name = "Bread", Price = 2.2m, ProductType = ProductType.Food, Description = "Bread is a staple food prepared from a dough of flour and water, usually by baking. Throughout recorded history it has been a prominent food in large parts of the world and is one of the oldest man-made foods, having been of significant importance since the dawn of agriculture."},
				new Product() {Name = "Peanuts", Price = 2.2m, ProductType = ProductType.Food, Description = "Peanuts is a syndicated daily and Sunday American comic strip written and illustrated by Charles M. Schulz that ran from October 2, 1950, to February 13, 2000, continuing in reruns afterward. The comic strip is among the most popular and influential in the history of comic strips, with 17,897 strips published in all,[1] making it \"arguably the longest story ever told by one human being\".[2] At its peak in the mid- to late 1960s, Peanuts ran in over 2,600 newspapers, with a readership of around 355 million in 75 countries, and was translated into 21 languages.[3] It helped to cement the four-panel gag strip as the standard in the United States,[4] and together with its merchandise earned Schulz more than $1 billion."},
				new Product() {Name = "Sausage", Price = 2.2m, ProductType = ProductType.Food, Description = "A sausage is a cylindrical meat product usually made from ground meat, often pork, beef, or veal, along with salt, spices and other flavourings, and breadcrumbs, encased by a skin. Typically, a sausage is formed in a casing traditionally made from intestine, but sometimes from synthetic materials. Sausages that are sold raw are cooked in many ways, including pan-frying, broiling and barbecuing. Some sausages are cooked during processing and the casing may then be removed."},
				new Product() {Name = "Wine", Price = 2.2m, ProductType = ProductType.Food, Description = "Yeast consumes the sugar in the grapes and converts it to ethanol, carbon dioxide, and heat. Different varieties of grapes and strains of yeasts produce different styles of wine. These variations result from the complex interactions between the biochemical development of the grape, the reactions involved in fermentation, the terroir, and the production process. Many countries enact legal appellations intended to define styles and qualities of wine. These typically restrict the geographical origin and permitted varieties of grapes, as well as other aspects of wine production. Wines not made from grapes include rice wine and fruit wines such as plum, cherry, pomegranate, currant and elderberry."},
			};

			foreach (var product in products)
			{
				if (this.GetProductByName(product.Name) == null)
				{
					this.DbContext.Products.Add(product);
				}
			}
			this.DbContext.SaveChanges();
		}
	}
}

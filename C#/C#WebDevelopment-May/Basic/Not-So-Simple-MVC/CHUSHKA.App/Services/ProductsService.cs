using System.Collections.Generic;
using System.Linq;
using CHUSHKA.App.ViewModels;
using CHUSHKA.Data;
using Microsoft.EntityFrameworkCore;

namespace CHUSHKA.App.Services
{
    public class ProductsService
    {
	    private readonly ChuskaContex db;

	    public ProductsService()
	    {
		    this.db = new ChuskaContex();
	    }

	    public IEnumerable<ProductViewModel> All()
	    {
		    var product = db.Products.Include(p=>p.Type)
			    .Select(p => new ProductViewModel()
			    {
				    Id = p.Id,
				    Name = p.Name,
					Description = p.Description,
					Price = p.Price,
					Type = p.Type.Name
			    });
		    return product;
	    }

	    public ProductViewModel GetById(int id)
	    {
		    var product = this.db.Products.Where(pr => pr.Id == id).Select(p => new ProductViewModel()
			    {
					Id = p.Id,
				    Name = p.Name,
				    Description = p.Description,
				    Price = p.Price,
				    Type = p.Type.Name
			})
			    .FirstOrDefault();

		    return product;
	    }

	    public void Delete(int id)
	    {
		    var game = this.db.Products.Find(id);
		    this.db.Products.Remove(game);

		    this.db.SaveChanges();
	    }
	}
}

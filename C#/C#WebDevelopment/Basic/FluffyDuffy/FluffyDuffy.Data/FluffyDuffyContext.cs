using System;
using System.Collections.Generic;
using System.Text;
using FluffyDuffy.Models;
using Microsoft.EntityFrameworkCore;

namespace FluffyDuffy.Data
{
    public class FluffyDuffyContext : DbContext
    {
		public DbSet<Cat> Cats { get; set; }
	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    if (!optionsBuilder.IsConfigured)
		    {
			    optionsBuilder.UseSqlServer("Server=.;Database=FluffyDuffyDb;Integrated Security=True");
		    }

		    base.OnConfiguring(optionsBuilder);
	    }
    }
}

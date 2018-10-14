using System;
using System.Collections.Generic;
using System.Text;
using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Data
{
    public class BooksContext : DbContext
    {
		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }
	    public DbSet<Borrower> Borrowers { get; set; }
		public DbSet<BooksBorrowers> BooksBorrowerses { get; set; }
	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    if (!optionsBuilder.IsConfigured)
		    {
			    optionsBuilder.UseSqlServer("Server=.;Database=LibraryDb;Integrated Security=True;");
		    }
		    base.OnConfiguring(optionsBuilder);
	    }

	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
			base.OnModelCreating(modelBuilder);

		    modelBuilder.Entity<Book>()
			    .HasMany(b => b.Borrowers)
			    .WithOne(b => b.Book)
			    .HasForeignKey(b => b.BookId);

		    modelBuilder.Entity<Borrower>()
			    .HasMany(b => b.Books)
			    .WithOne(b => b.Borrower)
			    .HasForeignKey(b => b.BorrowerId);

		    modelBuilder.Entity<BooksBorrowers>()
			    .HasKey(bb => new {bb.BookId, bb.BorrowerId});
	    }
    }
}

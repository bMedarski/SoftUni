using PetClinic.Models;

namespace PetClinic.Data
{
	using Microsoft.EntityFrameworkCore;

	public class PetClinicContext : DbContext
	{
		public PetClinicContext() { }

		public PetClinicContext(DbContextOptions options)
			: base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.ConnectionString);
			}
		}
		public DbSet<Animal> Animals { get; set; }

		public DbSet<AnimalAid> AnimalAids { get; set; }

		public DbSet<Passport> Passports { get; set; }

		public DbSet<Procedure> Procedures { get; set; }

		public DbSet<Vet> Vets { get; set; }

		public DbSet<ProcedureAnimalAid> ProceduresAnimalAids { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{



			builder.Entity<Animal>().HasKey(a => a.Id);

			builder.Entity<Animal>()
				.HasOne(p => p.Passport)
				.WithOne(i => i.Animal)
				.HasForeignKey<Passport>(b => b.AnimalId);

			builder.Entity<Passport>()
				.HasOne(p => p.Animal)
				.WithOne(i => i.Passport)
				.HasForeignKey<Animal>(b => b.PassportSerialNumber);

			builder.Entity<Passport>().HasKey(p => p.SerialNumber);

			builder.Entity<Vet>().HasAlternateKey(s => s.PhoneNumber)
				.HasName("PhoneNumber"); ;

			builder.Entity<AnimalAid>().HasAlternateKey(s => s.Name)
				.HasName("Name");

			builder.Entity<AnimalAid>().Property(s => s.Name);

			builder.Entity<Procedure>().HasOne(c => c.Animal)
				.WithMany(u => u.Procedures)
				.HasForeignKey(c => c.AnimalId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Procedure>().HasOne(c => c.Vet)
				.WithMany(u => u.Procedures)
				.HasForeignKey(c => c.VetId)
				.OnDelete(DeleteBehavior.Restrict);


			builder.Entity<ProcedureAnimalAid>().HasKey(i => new { i.AnimalAidId, i.ProcedureId });

			builder.Entity<ProcedureAnimalAid>().HasOne(oi => oi.AnimalAid)
				.WithMany(o => o.AnimalAidProcedures)
				.HasForeignKey(oi => oi.AnimalAidId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<ProcedureAnimalAid>().HasOne(oi => oi.Procedure)
				.WithMany(i => i.ProcedureAnimalAids)
				.HasForeignKey(oi => oi.ProcedureId)
				.OnDelete(DeleteBehavior.Restrict); ;
		}
	}
}

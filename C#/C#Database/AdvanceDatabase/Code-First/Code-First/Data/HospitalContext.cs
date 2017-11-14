using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
	public class HospitalContext : DbContext
	{
		public HospitalContext() { }

		public HospitalContext(DbContextOptions options)
			: base(options) { }

		public DbSet<Patient> Patients { get; set; }

		public DbSet<Diagnose> Diagnoses { get; set; }

		public DbSet<Visitation> Visitations { get; set; }

		public DbSet<Medicament> Medicaments { get; set; }

		public DbSet<PatientMedicament> PatientsMedicaments { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			if (!builder.IsConfigured)
			{
				builder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Patient>(entity =>
			{

				entity.HasKey(p => p.PatientId);

				entity.Property(e => e.FirstName)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(true);

				entity.Property(e => e.LastName)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(true);

				entity.Property(e => e.Address)
					.IsRequired()
					.HasMaxLength(250)
					.IsUnicode(true);

				entity.Property(e => e.Email)
					.IsRequired()
					.HasMaxLength(80)
					.IsUnicode(false);

				entity.Property(e => e.HasInsurance)
					.HasDefaultValue(true);
			});

			modelBuilder.Entity<Diagnose>(entity =>
			{
				entity.HasKey(p => p.DiagnoseId);

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(true);

				entity.Property(e => e.Comments)
					.IsRequired(false)
					.HasMaxLength(250)
					.IsUnicode(true);

				entity.HasOne(e => e.Patient)
					.WithMany(e => e.Diagnoses)
					.HasForeignKey(e => e.DiagnoseId);
			});

			modelBuilder.Entity<Visitation>(entity =>
			{
				entity.HasKey(p => p.VisitationId);

				entity.Property(e => e.Date)
					.IsRequired()
					.HasColumnType("DATETIME2")
					.HasDefaultValueSql("GETDATE()"); ;

				entity.Property(e => e.Comments)
					.IsRequired(false)
					.HasMaxLength(250)
					.IsUnicode(true);

				entity.HasOne(e => e.Patient)
					.WithMany(e => e.Visitations)
					.HasForeignKey(e => e.VisitationId);
			});

			modelBuilder.Entity<Medicament>(entity =>
			{
				entity.HasKey(p => p.MedicamentId);

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50)
					.IsUnicode(true);	
			});

			modelBuilder.Entity<PatientMedicament>(entity =>
			{
				entity.HasOne(e => e.Patient)
				.WithMany(e => e.Prescriptions)
				.HasForeignKey(e => e.PatiantId);

				entity.HasOne(e => e.Medicament)
					.WithMany(e => e.Prescriptions)
					.HasForeignKey(e => e.MedicamentId);

				entity.HasKey(e => new {e.Medicament,e.PatiantId });

			});
		}
	}
}

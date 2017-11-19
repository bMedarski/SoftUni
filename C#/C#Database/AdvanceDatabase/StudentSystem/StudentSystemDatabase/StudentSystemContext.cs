using System;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
	public class StudentSystemContext : DbContext
	{
		public StudentSystemContext()
		{

		}

		public StudentSystemContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Homework> HomeworkSubmissions { get; set; }
		public DbSet<Resource> Resources { get; set; }
		public DbSet<StudentCourse> StudentCourses { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=True;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>(entity =>
			{
				entity.HasKey(e => e.StudentId);

				entity.Property(e => e.Name)
					.HasMaxLength(100);

				entity.Property(e => e.PhoneNumber)
					.HasMaxLength(10)
					.IsRequired(false)
					.IsUnicode(false);

				entity.Property(e => e.Birthday)
					.IsRequired(false)
					.HasColumnType("DATETIME2");

				entity.Property(e => e.RegisteredOn)
					.HasColumnType("DATETIME2");

				entity.HasMany(e => e.CourseEnrollments)
					.WithOne(e => e.Student)
					.HasForeignKey(e => e.CourseId);
			});

			modelBuilder.Entity<Course>(entity =>
			{
				entity.HasKey(e => e.CourseId);

				entity.Property(e => e.Name)
					.HasMaxLength(80);

				entity.Property(e => e.StartDate)
					.HasColumnType("DATETIME2");
				entity.Property(e => e.EndDate)
					.HasColumnType("DATETIME2");

				entity.Property(e => e.Description)
					.IsRequired(false);
				entity.HasMany(e => e.StudentsEnrolled)
					.WithOne(e => e.Course)
					.HasForeignKey(e => e.StudentId);
			});

			modelBuilder.Entity<Resource>(entity =>
			{
				entity.HasKey(e => e.ResourceId);

				entity.Property(e => e.Name)
					.HasMaxLength(50);

				entity.Property(e => e.Url)
					.IsUnicode(false);

				entity.HasOne(e => e.Course)
					.WithMany(e => e.Resources)
					.HasForeignKey(e => e.CourseId);
			});
			modelBuilder.Entity<Homework>(entity =>
			{
				entity.ToTable("HomeworkSubmissions"); 
				entity.HasKey(e => e.HomeworkId);

				entity.Property(e => e.SubmissionTime)
					.HasColumnType("DATETIME2");

				entity.Property(e => e.Content)
					.IsRequired(false);

				entity.HasOne(e => e.Student)
					.WithMany(e => e.HomeworkSubmissions)
					.HasForeignKey(e => e.StudentId);

				entity.HasOne(e => e.Course)
					.WithMany(e => e.HomeworkSubmissions)
					.HasForeignKey(e => e.CourseId);

			});

			modelBuilder.Entity<StudentCourse>(entity =>
			{
				entity.HasKey(e => new {e.CourseId, e.StudentId});

			});
		}
	}
}

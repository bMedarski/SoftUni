﻿namespace IRuneData
{
	using IRuneModels;
	using Microsoft.EntityFrameworkCore;
	public class IRuneDbContext:DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Track> Tracks { get; set; }
		public DbSet<Album> Albums { get; set; }
		public DbSet<TrackAlbum> TrackAlbums { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseSqlServer(
					@"Server=.;Database=IRuneDb;Integrated Security=True;");
		}
	}
}

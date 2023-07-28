using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Artist> Artists => Set<Artist>();
        public DbSet<Album> Albums => Set<Album>();
        public DbSet<Song> Songs => Set<Song>();
        public DbSet<GenreSong> GenreSongs => Set<GenreSong>();
        public DbSet<SongArtist> SongArtist => Set<SongArtist>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);


            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "R&B"
                },
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Rap"
                },
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Pop"
                },
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Disco"
                });
        }
    }
}

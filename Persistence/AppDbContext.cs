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


            var genre1 = new Genre { Id = Guid.NewGuid(), Name = "R&B" };
            var genre2 = new Genre { Id = Guid.NewGuid(), Name = "Pop" };
            var genre3 = new Genre { Id = Guid.NewGuid(), Name = "Rock" };
            var genre4 = new Genre { Id = Guid.NewGuid(), Name = "Country" };
            var genre5 = new Genre { Id = Guid.NewGuid(), Name = "Rap" };

            var artist1 = new Artist { Id = Guid.NewGuid(), Name = "Billie Eilish", About = "", AvatarPath = "/contents/" };
            var artist2 = new Artist { Id = Guid.NewGuid(), Name = "Harry Style", About = "", AvatarPath = "/contents/" };
            var artist3 = new Artist { Id = Guid.NewGuid(), Name = "The Weeknd", About = "", AvatarPath = "/contents/" };
            var artist4 = new Artist { Id = Guid.NewGuid(), Name = "Ariana Grande", About = "", AvatarPath = "/contents/" };

            var song1 = new Song { Id = Guid.NewGuid(), Name = "Happier Than Ever", CoverPath = "", AudioPath = "", ReleaseDate = DateTime.Now };
            var song2 = new Song { Id = Guid.NewGuid(), Name = "Blinding Lights", CoverPath = "", AudioPath = "", ReleaseDate = DateTime.Now };
            var song3 = new Song { Id = Guid.NewGuid(), Name = "Save Your Tears(Remix)", CoverPath = "", AudioPath = "", ReleaseDate = DateTime.Now };

            var gs1 = new GenreSong
            {
                GenreId = genre1.Id,
                SongId = song1.Id
            };
            var gs2 = new GenreSong
            {
                GenreId = genre2.Id,
                SongId = song2.Id
            };
            var gs3 = new GenreSong
            {
                GenreId = genre2.Id,
                SongId = song3.Id
            };

            var gs4 = new GenreSong
            {
                GenreId = genre4.Id,
                SongId = song3.Id
            };
            //song1.GenreSongs.Add(new GenreSong
            //{
            //    GenreId = genre1.Id,
            //    SongId = song1.Id
            //});
            //song2.GenreSongs.Add(new GenreSong
            //{
            //    GenreId = genre2.Id,
            //    SongId = song2.Id
            //});
            //song3.GenreSongs.Add(new GenreSong
            //{
            //    GenreId = genre2.Id,
            //    SongId = song3.Id
            //});
            //song3.GenreSongs.Add(new GenreSong
            //{
            //    GenreId = genre4.Id,
            //    SongId = song3.Id
            //});

            var sa1 = new SongArtist
            {
                ArtistId = artist1.Id,
                SongId = song1.Id
            };

            var sa2 = new SongArtist
            {
                ArtistId = artist3.Id,
                SongId = song2.Id
            };

            var sa3 = new SongArtist
            {
                ArtistId = artist3.Id,
                SongId = song3.Id
            };

            var sa4 = new SongArtist
            {
                ArtistId = artist4.Id,
                SongId = song3.Id
            };
            //song1.SongArtists.Add(new SongArtist
            //{
            //    ArtistId = artist1.Id,
            //    SongId = song1.Id
            //});
            //song2.SongArtists.Add(new SongArtist
            //{
            //    ArtistId = artist3.Id,
            //    SongId = song2.Id
            //});
            //song3.SongArtists.Add(new SongArtist
            //{
            //    ArtistId = artist3.Id,
            //    SongId = song3.Id
            //});
            //song3.SongArtists.Add(new SongArtist
            //{
            //    ArtistId = artist4.Id,
            //    SongId = song3.Id
            //});

            modelBuilder.Entity<Genre>().HasData(genre1, genre2, genre3, genre4, genre5);
            modelBuilder.Entity<Song>().HasData(song1, song2, song3);
            modelBuilder.Entity<Artist>().HasData(artist1, artist2, artist3, artist4);
            modelBuilder.Entity<GenreSong>().HasData(gs1, gs2, gs3, gs4);
            modelBuilder.Entity<SongArtist>().HasData(sa1, sa2, sa3, sa4);
        }
    }
}

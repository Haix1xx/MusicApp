using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class GenreSongConfiguration : IEntityTypeConfiguration<GenreSong>
    {
        public void Configure(EntityTypeBuilder<GenreSong> builder)
        {
            builder.HasKey(x => new { x.SongId, x.GenreId });

            builder.HasOne(x => x.Song)
                   .WithMany(song => song.GenreSongs)
                   .HasForeignKey(x => x.SongId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Genre)
                   .WithMany(genre => genre.GenreSongs)
                   .HasForeignKey(x => x.GenreId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

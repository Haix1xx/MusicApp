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
    public class SongArtistConfiguration : IEntityTypeConfiguration<SongArtist>
    {
        public void Configure(EntityTypeBuilder<SongArtist> builder)
        {
            builder.HasKey(x => new {x.ArtistId, x.SongId});

            builder.HasOne(x => x.Artist)
                   .WithMany(artist => artist.SongArist)
                   .HasForeignKey(x => x.ArtistId).OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(x => x.Song)
                    .WithMany(song => song.SongArtists)
                    .HasForeignKey(x => x.SongId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

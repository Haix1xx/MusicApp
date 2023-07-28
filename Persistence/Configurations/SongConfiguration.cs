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
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.AudioPath).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Duration).HasMaxLength(10);
            builder.Property(x => x.ReleaseDate).IsRequired();
            builder.Property(x => x.CoverPath).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.Album).WithMany(a => a.Songs).HasForeignKey(x => x.AlbumId);
        }
    }
}

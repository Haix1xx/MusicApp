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
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CoverPath).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ArtistId).IsRequired();
            builder.HasOne(x => x.Artist).WithMany(a => a.Albums).HasForeignKey(x => x.ArtistId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SongArtist
    {
        public Guid SongId { get; set; }
        public Song Song { get; set; } = default!;
        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; } = default!;
    }
}

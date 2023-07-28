using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Song : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string CoverPath { get; set; } = default!;
        public string AudioPath { get; set; } = default!;
        public string Duration { get; set; } = "0";
        public DateTime ReleaseDate { get; set; }
        public Guid AlbumId { get; set; }
        public Album Album { get; set; } = default!;
        public IList<SongArtist> SongArtists { get; set; } = new List<SongArtist>();
        public IList<GenreSong> GenreSongs { get; set; } = new List<GenreSong>();

        

    }
}

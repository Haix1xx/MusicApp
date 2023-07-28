using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Artist : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string? About { get; set; }
        public string AvatarPath { get; set; } = default!;
        public ICollection<SongArtist> SongArist { get; set; } = new HashSet<SongArtist>();
        public IEnumerable<Album> Albums { get; set; } = new List<Album>();
    }
}

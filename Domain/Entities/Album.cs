using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Album : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }

        public string CoverPath { get; set; } = default!;
        public IEnumerable<Song> Songs { get; set; } = new List<Song>();
        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; } = default!;
    }
}

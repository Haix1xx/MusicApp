using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GenreSong
    {
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; } = default!;
        public Guid SongId { get; set; }
        public Song Song { get; set; } = default!;
    }
}

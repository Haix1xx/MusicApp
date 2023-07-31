using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Songs
{
    public class SongDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string CoverPath { get; set; } = default!;
        public string AudioPath { get; set; } = default!;
        public string Duration { get; set; } = "0";
        public DateTime ReleaseDate { get; set; }
        public IList<ArtistDto> Artists { get; set; } = new List<ArtistDto>();
        public IList<GenreDto> Genres { get; set; } = new List<GenreDto>();

        public class ArtistDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = default!;
        }

        public class GenreDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = default!;
        }
    }
}

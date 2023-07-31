using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Artists
{
    public class ArtistDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? About { get; set; }
        public string AvatarPath { get; set; } = default!;
    }
}

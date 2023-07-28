using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Abstractions
{
    public interface IArtistRepository
    {
        Task<IEnumerable<Artist>?> ListAsync();
        Task AddAsync(Artist artist);
        void Update(Artist artist);
        void Delete(Artist artist);
        Task<Artist?> FindByIdAsync(Guid id);
    }
}

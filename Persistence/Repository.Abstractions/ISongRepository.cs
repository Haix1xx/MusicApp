using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Abstractions
{
    public interface ISongRepository
    {
        Task<IEnumerable<Song>?> ListAsync();
        Task AddAsync(Song song);
        void Update(Song song);
        void Delete(Song song);
        Task<Song?> FindByIdAsync(Guid id);
    }
}

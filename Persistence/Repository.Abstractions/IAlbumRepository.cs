using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Abstractions
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>?> ListAsync();
        Task AddAsync(Album album);
        void Update(Album album);
        void Delete(Album album);
        Task<Album?> FindByIdAsync(Guid id);
    }
}

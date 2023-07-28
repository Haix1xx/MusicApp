using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Abstractions
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>?> ListAsync();
        Task AddAsync(Genre genre);
        Task<Genre?> FindByIdAsync(Guid id);
        void Update(Genre genre);
        void Delete(Genre genre);
    }
}

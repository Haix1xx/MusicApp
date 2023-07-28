using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenreRepository : BaseRepository, IGenreRepository
    {
        public GenreRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
        }

        public void Delete(Genre genre)
        {
            _context.Genres.Remove(genre);  
        }

        public async Task<Genre?> FindByIdAsync(Guid id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<IEnumerable<Genre>?> ListAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public void Update(Genre genre)
        {
            _context.Update(genre);
        }
    }
}

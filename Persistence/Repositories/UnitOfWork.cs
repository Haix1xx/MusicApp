using Persistence.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IGenreRepository _genreRepository = default!;
        private readonly IArtistRepository _artistRepository = default!;
        private readonly IAlbumRepository _albumRepository = default!;
        private readonly ISongRepository _songRepository = default!;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IGenreRepository GenreRepository
        {
            get { return _genreRepository ?? new GenreRepository(_context); }
        }

        public IArtistRepository ArtistRepository
        {
            get { return _artistRepository ?? new ArtistRepository(_context);  }
        }

        public IAlbumRepository AlbumRepository
        {
            get { return _albumRepository ?? new AlbumRepository(_context); }
        }

        public ISongRepository SongRepository
        {
            get { return _songRepository ?? new SongRepository(_context); }
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void RollBack()
        {
            _context.Dispose();
        }

        public async Task RollBackAsync()
        {
            await _context.DisposeAsync();
        }
    }
}

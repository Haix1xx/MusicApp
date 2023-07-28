using Domain.Entities;
using MusicApp.Service.Abstractions;
using Persistence.Repository.Abstractions;

namespace MusicApp.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepo;
        public GenreService(IGenreRepository genreRepo)
        {
            _genreRepo = genreRepo;
        }
        public async Task<IEnumerable<Genre>?> ListAsync()
        {
            return await _genreRepo.ListAsync();
        }
    }
}

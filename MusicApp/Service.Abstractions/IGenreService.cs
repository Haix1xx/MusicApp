using Domain.Entities;

namespace MusicApp.Service.Abstractions
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>?> ListAsync();

    }
}

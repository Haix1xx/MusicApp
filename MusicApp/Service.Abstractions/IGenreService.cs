using Domain.Entities;
using MusicApp.Service.Abstractions.Communication;

namespace MusicApp.Service.Abstractions
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>?> ListAsync();
        Task<BaseResponse> AddAsync(Genre genre);
        Task<BaseResponse> UpdateAsync(Guid id, Genre genre);
        Task<BaseResponse> DeleteAsync(Guid id);
    }
}

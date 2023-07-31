using Domain.Entities;
using MusicApp.Service.Abstractions.Communication;

namespace MusicApp.Service.Abstractions
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>?> ListAsync();
        Task<BaseResponse> AddAsync(Artist genre);
        Task<BaseResponse> UpdateAsync(Guid id, Artist genre);
        Task<BaseResponse> DeleteAsync(Guid id);

        Task<Artist?> GetByIdAsync(Guid id);
    }
}

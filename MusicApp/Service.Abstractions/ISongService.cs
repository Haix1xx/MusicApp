using Domain.Entities;
using MusicApp.Service.Abstractions.Communication;

namespace MusicApp.Service.Abstractions
{
    public interface ISongService
    {
        Task<IEnumerable<Song>?> ListAsync();
        Task<BaseResponse> AddAsync(Song song);
        Task<BaseResponse> UpdateAsync(Guid id, Song song);
        Task<BaseResponse> DeleteAsync(Guid id);

        Task<Song?> GetByIdAsync(Guid id);
    }
}

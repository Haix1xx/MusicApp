using Domain.Entities;
using MusicApp.Service.Abstractions.Communication;

namespace MusicApp.Service.Abstractions
{
    public interface IAlbumService
    {
        Task<IEnumerable<Album>?> ListAsync();
        Task<BaseResponse> AddAsync(Album album);
        Task<BaseResponse> UpdateAsync(Guid id, Album album);
        Task<BaseResponse> DeleteAsync(Guid id);
    }
}

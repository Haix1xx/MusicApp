using Domain.Entities;
using Humanizer.Localisation;
using MusicApp.Service.Abstractions;
using MusicApp.Service.Abstractions.Communication;
using Persistence.Repository.Abstractions;

namespace MusicApp.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlbumService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> AddAsync(Album album)
        {
            try
            {
                await _unitOfWork.AlbumRepository.AddAsync(album);
                await _unitOfWork.CommitAsync();
                return new BaseResponse(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse(ex.Message);
            }
        }

        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            var existingAlbum = await _unitOfWork.AlbumRepository.FindAsync(id);
            if (existingAlbum == null)
            {
                return new BaseResponse("Album not found");
            }
            try
            {
                _unitOfWork.AlbumRepository.Remove(existingAlbum);
                await _unitOfWork.CommitAsync();
                return new BaseResponse(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse(ex.Message);
            }
        }

        public async Task<IEnumerable<Album>?> ListAsync()
        {
            return await _unitOfWork.AlbumRepository.GetAllAsync();
        }

        public async Task<BaseResponse> UpdateAsync(Guid id, Album album)
        {
            var existingAlbum = await _unitOfWork.AlbumRepository.FindAsync(id);
            if (existingAlbum == null)
            {
                return new BaseResponse("Genre not found");
            }

            existingAlbum.Name = album.Name;
            existingAlbum.CoverPath = album.CoverPath;
            existingAlbum.Description = album.Description;
            try
            {
                _unitOfWork.AlbumRepository.Remove(existingAlbum);
                await _unitOfWork.CommitAsync();
                return new BaseResponse(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse(ex.Message);
            }
        }
    }
}

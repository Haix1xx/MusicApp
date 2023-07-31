using Domain.Entities;
using Humanizer.Localisation;
using MusicApp.Service.Abstractions;
using MusicApp.Service.Abstractions.Communication;
using Persistence.Repository.Abstractions;

namespace MusicApp.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArtistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Artist?> GetByIdAsync(Guid id)
        {
            return await _unitOfWork.ArtistRepository.FindAsync(id);
        }
        public async Task<BaseResponse> AddAsync(Artist artist)
        {
            try
            {
                await _unitOfWork.ArtistRepository.AddAsync(artist);
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
            var existingArtist = await _unitOfWork.ArtistRepository.FindAsync(id);
            if (existingArtist == null)
            {
                return new BaseResponse("Genre not found");
            }
            try
            {
                _unitOfWork.ArtistRepository.Remove(existingArtist);
                await _unitOfWork.CommitAsync();
                return new BaseResponse(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse(ex.Message);
            }
        }

        public async Task<IEnumerable<Artist>?> ListAsync()
        {
            return await _unitOfWork.ArtistRepository.GetAllAsync();
        }

        public async Task<BaseResponse> UpdateAsync(Guid id, Artist artist)
        {
            var existingArtist = await _unitOfWork.ArtistRepository.FindAsync(id);
            if (existingArtist == null)
            {
                return new BaseResponse("Genre not found");
            }

            existingArtist.Name = artist.Name;
            existingArtist.About = artist.About;
            try
            {
                _unitOfWork.ArtistRepository.Update(existingArtist);
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

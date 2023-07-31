using Domain.Entities;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using MusicApp.Service.Abstractions;
using MusicApp.Service.Abstractions.Communication;
using Persistence.Repositories;
using Persistence.Repository.Abstractions;

namespace MusicApp.Services
{
    public class SongService : ISongService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SongService> _logger;

        public SongService(IUnitOfWork unitOfWork, ILogger<SongService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<Song?> GetByIdAsync(Guid id)
        {
            var song =_unitOfWork.SongRepository
                                .FindByCondition(s => s.Id == id);

            if (song == null )
                return null;
            return await song.Include(s => s.SongArtists)
                                .ThenInclude(sa => sa.Artist)
                                .Include(s => s.GenreSongs)
                                .ThenInclude(gs => gs.Genre)
                                .AsSplitQuery()
                                .FirstOrDefaultAsync();

        }
        public async Task<BaseResponse> AddAsync(Song song)
        {
            try
            {
                await _unitOfWork.SongRepository.AddAsync(song);
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
            var existingSong = await _unitOfWork.SongRepository.FindAsync(id);
            if (existingSong == null)
            {
                return new BaseResponse("Genre not found");
            }
            try
            {
                _unitOfWork.SongRepository.Remove(existingSong);
                await _unitOfWork.CommitAsync();
                return new BaseResponse(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse(ex.Message);
            }
        }

        public async Task<IEnumerable<Song>?> ListAsync()
        {
            return await _unitOfWork.SongRepository.FindAll()
                .Include(song => song.SongArtists)
                .ThenInclude(song_artist => song_artist.Artist)
                .Include(song => song.GenreSongs)
                .ThenInclude(genresong => genresong.Genre)
                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task<BaseResponse> UpdateAsync(Guid id, Song song)
        {
            var existingSong = await _unitOfWork.SongRepository.FindAsync(id);
            if (existingSong == null) { return new BaseResponse("Song not found"); }
            existingSong.Name = song.Name;
            existingSong.AudioPath = song.AudioPath;
            existingSong.AlbumId = song.AlbumId;

            try
            {
                _unitOfWork.SongRepository.Remove(existingSong);
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

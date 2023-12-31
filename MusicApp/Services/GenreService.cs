﻿using Domain.Entities;
using Humanizer.Localisation;
using MusicApp.Service.Abstractions;
using MusicApp.Service.Abstractions.Communication;
using Persistence.Repository.Abstractions;

namespace MusicApp.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> AddAsync(Genre genre)
        {
            try
            {
                await _unitOfWork.GenreRepository.AddAsync(genre);
                await _unitOfWork.CommitAsync();
                return new BaseResponse(true);
            }
            catch(Exception ex)
            {
                return new BaseResponse(ex.Message);
            }
        }

        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            var existingGenre = await _unitOfWork.GenreRepository.FindAsync(id);
            if (existingGenre == null)
            {
                return new BaseResponse("Genre not found");
            }
            try
            {
                _unitOfWork.GenreRepository.Remove(existingGenre);
                await _unitOfWork.CommitAsync();
                return new BaseResponse(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse(ex.Message);
            }
        }

        public async Task<IEnumerable<Genre>?> ListAsync()
        {
            return await _unitOfWork.GenreRepository.GetAllAsync();
        }

        public async Task<BaseResponse> UpdateAsync(Guid id, Genre genre)
        {
            var existingGenre = await _unitOfWork.GenreRepository.FindAsync(id);
            if (existingGenre == null)
            {
                return new BaseResponse("Genre not found");
            }

            existingGenre.Name = genre.Name;
            try
            {
                _unitOfWork.GenreRepository.Remove(existingGenre);
                await _unitOfWork.CommitAsync();
                return new BaseResponse(true);
            }
            catch(Exception ex)
            {
                return new BaseResponse(ex.Message);
            }
        }
    }
}

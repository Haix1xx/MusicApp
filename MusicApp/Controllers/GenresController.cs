using AutoMapper;
using Contracts.Genres;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Service.Abstractions;
using System.Runtime.CompilerServices;

namespace MusicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        public GenresController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var genres = await _genreService.ListAsync();
            if (genres == null)
            {
                return NoContent();
            }
            return Ok(_mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDto>>(genres));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveGenreDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Errors");
            }

            var genre = _mapper.Map<SaveGenreDto, Genre>(resource);

            var result = await _genreService.AddAsync(genre);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] SaveGenreDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Errors");
            }
            var genre = _mapper.Map<SaveGenreDto, Genre>(resource);

            var result = await _genreService.UpdateAsync(id, genre);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _genreService.DeleteAsync(id);
            if (!result.IsSuccess) 
            {
                return BadRequest(result.Error);
            }

            return Ok(result);
        }
    }
}

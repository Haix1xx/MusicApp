using AutoMapper;
using Contracts.Artists;
using Contracts.Genres;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Service.Abstractions;
using MusicApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;
        public ArtistsController(IArtistService artistService, IMapper mapper)
        {
            _artistService = artistService;
            _mapper = mapper;
        }
        // GET: api/<ArtistsController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var artists = await _artistService.ListAsync();
            if (artists == null)
            {
                return NoContent();
            }
            return Ok(_mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistDto>>(artists));
        }

        // GET api/<ArtistsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var artist = await _artistService.GetByIdAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Artist, ArtistDto> (artist));
        }

        // POST api/<ArtistsController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveArtistDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Errors");
            }

            var artist = _mapper.Map<SaveArtistDto, Artist>(resource);

            var result = await _artistService.AddAsync(artist);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return Ok(result);
        }

        // PUT api/<ArtistsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] SaveArtistDto resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Errors");
            }
            var artist = _mapper.Map<SaveArtistDto, Artist>(resource);

            var result = await _artistService.UpdateAsync(id, artist);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _artistService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return Ok(result);
        }
    }
}

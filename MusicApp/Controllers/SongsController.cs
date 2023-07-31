using AutoMapper;
using Contracts.Songs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Service.Abstractions;
using NuGet.Protocol;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        // GET: api/<SongsController>
        private readonly ISongService _songService;
        private readonly IMapper _mapper;
        private readonly ILogger<ILogger<SongsController>> _logger;
        public SongsController(ISongService songService, IMapper mapper, ILogger<ILogger<SongsController>> logger)
        {
            _songService = songService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var songs = await _songService.ListAsync();
            if (songs == null)
                return NoContent();
            foreach(var song in songs)
            {
                _logger.LogInformation(song.Name);
                foreach (var item in song.SongArtists)
                    _logger.LogCritical(item.Artist.Name);
            }
            return Ok(_mapper.Map<IEnumerable<SongDto>>(songs));
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var song = await _songService.GetByIdAsync(id);
            if (song == null)
                return NoContent();
            return Ok(_mapper.Map<SongDto>(song));
        }

        // POST api/<SongsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

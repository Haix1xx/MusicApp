using AutoMapper;
using Contracts.Artists;
using Contracts.Genres;
using Contracts.Songs;
using Domain.Entities;
using System.Net;

namespace Contracts
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<Genre, GenreDto>();
            CreateMap<SaveGenreDto, Genre>()
                .ForMember(src => src.Id, opt => opt
                .MapFrom(src => Guid.NewGuid()));
            CreateMap<Artist, ArtistDto>();
            CreateMap<Artist, Songs.SongDto.ArtistDto>();
            CreateMap<Genre, Songs.SongDto.GenreDto>();
            CreateMap<Song, SongDto>()
                .ForMember(src => src.Artists, opt => opt.MapFrom(src => src.SongArtists.Select(sa => sa.Artist).ToList()))
                .ForMember(src => src.Genres, opt => opt.MapFrom(src => src.GenreSongs.Select(gs => gs.Genre).ToList()));


        }


        public IList<SongDto.ArtistDto> GetArtistFromSong(IList<SongArtist> songArtists)
        {
            var result = new List<SongDto.ArtistDto>();
            foreach(var song_artist in songArtists)
            {
                result.Add(new SongDto.ArtistDto
                {
                    Id = song_artist.ArtistId,
                    Name = song_artist.Artist.Name
                });
            }
            return result;
        }
        public IList<SongDto.ArtistDto> GetGenreFromSong(IList<GenreSong> genreSongs)
        {
            var result = new List<SongDto.ArtistDto>();
            foreach (var genre in genreSongs)
            {
                result.Add(new SongDto.ArtistDto
                {
                    Id = genre.GenreId,
                    Name = genre.Genre.Name
                });
            }
            return result;
        }
    }
}

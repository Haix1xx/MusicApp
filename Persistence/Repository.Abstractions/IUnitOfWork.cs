using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Abstractions
{
    public interface IUnitOfWork
    {
        IGenreRepository GenreRepository { get; }
        IArtistRepository ArtistRepository { get; }
        IAlbumRepository AlbumRepository { get; }
        ISongRepository SongRepository { get; }

        void Commit();
        void RollBack();
        Task CommitAsync();
        Task RollBackAsync();
    }
}

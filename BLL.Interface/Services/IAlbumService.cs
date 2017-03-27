using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IAlbumService
    {
        void CreateAlbum(AlbumEntity album);
        IEnumerable<AlbumEntity> GetByUserId(int userId);
        int GetAlbumId(string albumName);
    }
}
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IUnitOfWork uow, IAlbumRepository repository)
        {
            _albumRepository = repository;
            _uow = uow;
        }

        public void CreateAlbum(AlbumEntity album)
        {
            _albumRepository.Create(album.ToDalAlbum());
            _uow.Commit();
        }

        public IEnumerable<AlbumEntity> GetByUserId(int userId)
        {
            return _albumRepository.GetAll()
                .Where(album => album.UserId == userId)
                .Select(album => album.ToBllAlbum());
        }

        public int GetAlbumId(string albumName)
        {
            return _albumRepository.GetAlbumId(albumName);
        }
    }
}
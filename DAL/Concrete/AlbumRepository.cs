using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;

namespace DAL.Concrete
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly DbContext _context;

        public AlbumRepository(DbContext uow)
        {
            _context = uow;
        }

        public IEnumerable<DalAlbum> GetAll()
        {
           return  _context.Set<Album>().Select(album => new DalAlbum()
            {
                Id = album.Id,
                Name = album.Name,
                UserId = album.UserId
            });
        }

        public DalAlbum GetById(int key)
        {
            throw new System.NotImplementedException();
        }

        public void Create(DalAlbum e)
        {
            var album = new Album()
            {
                Name = e.Name,
                UserId = e.UserId
            };
            _context.Set<Album>().Add(album);
        }

        public int GetAlbumId(string albumName)
        {
           return  _context.Set<Album>().FirstOrDefault(album => album.Name == albumName).Id;
        }

        //public void Update(int albumId)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
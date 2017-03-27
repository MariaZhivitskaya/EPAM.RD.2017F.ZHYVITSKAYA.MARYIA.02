using System.Collections.Generic;
using System.Data.Entity;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;
using System.Linq;

namespace DAL.Concrete
{
    public class ImageRepository : IImageRepository
    {
        private readonly DbContext _context;

        public ImageRepository(DbContext uow)
        {
            _context = uow;
        }

        public IEnumerable<DalImage> GetAll()
        {
            return _context.Set<Image>().Select(img => new DalImage()
            {
                Id = img.Id,
                Picture = img.Picture,
                AlbumId = img.AlbumId,
                Name = img.Name,
                Description = img.Description,
                CreationDate = img.CreationDate,
                ExtensionId = img.ExtensionId
            });
        }

        public DalImage GetById(int key)
        {
            var ormImg = _context.Set<Image>().FirstOrDefault(image => image.Id == key);
            return new DalImage()
            {
                Id = ormImg.Id,
                Picture = ormImg.Picture,
                AlbumId = ormImg.AlbumId,
                Name = ormImg.Name,
                Description = ormImg.Description,
                CreationDate = ormImg.CreationDate,
                ExtensionId = ormImg.ExtensionId
            };
        }

        public void Create(DalImage e)
        {
            var image = new Image()
            {
                Picture = e.Picture,
                AlbumId = e.AlbumId,
                Name = e.Name,
                Description = e.Description,
                CreationDate = e.CreationDate,
                ExtensionId = e.ExtensionId
            };
            _context.Set<Image>().Add(image);
        }

        public void Update(int imageId)
        {
            var ormImg = _context.Set<Image>().FirstOrDefault(image => image.Id == imageId);
            _context.SaveChanges();
        }
    }
}
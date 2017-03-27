using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _uow;
        private readonly IImageRepository _imageRepository;

        public ImageService(IUnitOfWork uow, IImageRepository repository)
        {
            _imageRepository = repository;
            _uow = uow;
        }

        public void CreateImage(ImageEntity image)
        {
            _imageRepository.Create(image.ToDalImage());
            _uow.Commit();
        }

        public IEnumerable<ImageEntity> GetAllImageEntities()
        {
            return _imageRepository.GetAll().Select(img => img.ToBllImage());
        }

        public IEnumerable<ImageEntity> GetByAlbumId(int almubId)
        {
            return _imageRepository.GetAll().Where(img => img.AlbumId == almubId).Select(img => img.ToBllImage());
        }

        public ImageEntity GetImageEntity(int id)
        {
            return _imageRepository.GetById(id).ToBllImage();
        }
    }
}
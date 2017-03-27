using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IImageService
    {
        void CreateImage(ImageEntity image);
        IEnumerable<ImageEntity> GetAllImageEntities();
        IEnumerable<ImageEntity> GetByAlbumId(int almubId);
        ImageEntity GetImageEntity(int id);
    }
}
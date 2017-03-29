using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            return new DalUser()
            {
                Id = userEntity.Id,
                Email = userEntity.Email,
                Password = userEntity.Password,
                RoleId = userEntity.RoleId
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            if (dalUser == null)
                return null;

            return new UserEntity()
            {
                Id = dalUser.Id,
                Email = dalUser.Email,
                Password = dalUser.Password,
                RoleId = dalUser.RoleId
            };
        }

        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            return new RoleEntity()
            {
                Id = dalRole.Id,
                Description = dalRole.Description
            };
        }

        public static DalImage ToDalImage(this ImageEntity imageEntity)
        {
            return new DalImage()
            {
                Id = imageEntity.Id,
                Picture = imageEntity.Picture,
                AlbumId = imageEntity.AlbumId,
                Name = imageEntity.Name,
                Description = imageEntity.Description,
                CreationDate = imageEntity.CreationDate,
                ExtensionId = imageEntity.ExtensionId
            };
        }

        public static ImageEntity ToBllImage(this DalImage dalImage)
        {
            return new ImageEntity()
            {
                Id = dalImage.Id,
                Picture = dalImage.Picture,
                AlbumId = dalImage.AlbumId,
                Name = dalImage.Name,
                Description = dalImage.Description,
                CreationDate = dalImage.CreationDate,
                ExtensionId = dalImage.ExtensionId
            };
        }

        public static DalAlbum ToDalAlbum(this AlbumEntity albumEntity)
        {
            return new DalAlbum()
            {
                Id = albumEntity.Id,
                Name = albumEntity.Name,
                UserId = albumEntity.UserId
            };
        }

        public static AlbumEntity ToBllAlbum(this DalAlbum dalAlbum)
        {
            return new AlbumEntity()
            {
                Id = dalAlbum.Id,
                Name = dalAlbum.Name,
                UserId = dalAlbum.UserId
            };
        }

        public static DalExtension ToDalExtension(this ExtensionEntity extensionEntity)
        {
            return new DalExtension()
            {
                Id = extensionEntity.Id,
                Name = extensionEntity.Name
            };
        }

        public static ExtensionEntity ToBllExtension(this DalExtension dalExtension)
        {
            return new ExtensionEntity()
            {
                Id = dalExtension.Id,
                Name = dalExtension.Name
            };
        }

        public static DalSiteDescription ToDalSiteDescription(this SiteDescriptionEntity descriptionEntity)
        {
            return new DalSiteDescription()
            {
                Id = descriptionEntity.Id,
                Text = descriptionEntity.Text
            };
        }

        public static SiteDescriptionEntity ToBllSiteDescription(this DalSiteDescription dalDescription)
        {
            return new SiteDescriptionEntity()
            {
                Id = dalDescription.Id,
                Text = dalDescription.Text
            };
        }
    }
}
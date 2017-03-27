using BLL.Interface.Entities;
using WebApplication.ViewModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class WebApplicationMapper
    {
        public static UserEntity ToBllUser(this UserViewModel userViewModel) =>
           new UserEntity()
           {
               Id = userViewModel.Id,
               Email = userViewModel.Email,
               Password = userViewModel.Password,
               RoleId = userViewModel.RoleId
           };

        public static ImageEntity ToBllImage(this ImageViewModel imageViewModel) =>
            new ImageEntity()
            {
                Id = imageViewModel.Id,
                Picture = imageViewModel.Picture,
                AlbumId = imageViewModel.AlbumId,
                Name = imageViewModel.Name,
                Description = imageViewModel.Description,
                CreationDate = imageViewModel.CreationDate,
                ExtensionId = imageViewModel.ExtensionId
            };

        public static AlbumEntity ToBllAlbum(this AlbumViewModel albumViewModel) =>
            new AlbumEntity()
            {
                Id = albumViewModel.Id,
                Name = albumViewModel.Name,
                UserId = albumViewModel.UserId
            };

        public static ExtensionEntity ToBllExtension(this ExtensionViewModel extensionViewModel) =>
            new ExtensionEntity()
            {
                Id = extensionViewModel.Id,
                Name = extensionViewModel.Name
            };
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;
using WebApplication.Infrastructure.Mappers;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class AddController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAlbumService _albumService;
        private readonly IImageService _imageService;
        private readonly IExtensionService _extensionService;

        public AddController(IUserService uService, IAlbumService aService, IImageService iService, IExtensionService eService)
        {
            _userService = uService;
            _albumService = aService;
            _imageService = iService;
            _extensionService = eService;
        }

        [HttpPost]
        public bool AddAlbum(string albumName)
        {
            var email = Membership.GetUser().UserName;
            var userId = _userService.GetUserByEmail(email).Id;

            var album = new AlbumViewModel
            {
                Name = albumName,
                UserId = userId
            };
            
            /*
             * add check for an album with the same name!!!
             */

            _albumService.CreateAlbum(album.ToBllAlbum());
            return true;
        }

        [HttpPost]
        public bool AddImage(string image, string extension, string selectedAlbum, string name, string description)
        {
            var dataIndex = image.IndexOf("base64", StringComparison.Ordinal) + 7;
            var cleareData = image.Substring(dataIndex);
            var fileData = Convert.FromBase64String(cleareData);
            var bytes = fileData.ToArray();
            string realExtension = extension.Substring(extension.LastIndexOf('/') + 1);

            var albumId = _albumService.GetAlbumId(selectedAlbum);
            var existingExtension = _extensionService.GetAllExtensionEntities().Any(e => e.Name.Contains(realExtension));
            if (!existingExtension)
            {
                var newExtension = new ExtensionViewModel
                {
                    Name = realExtension
                };
                _extensionService.CreateExtension(newExtension.ToBllExtension());
            }

            var extensionId = _extensionService.GetExtensionId(realExtension);

            var img = new ImageViewModel
            {
                Picture = bytes,
                AlbumId = albumId,
                CreationDate = DateTime.Now,
                Description = description,
                Name = name,
                ExtensionId = extensionId
            };

            _imageService.CreateImage(img.ToBllImage());

            return true;
        }
    }
}
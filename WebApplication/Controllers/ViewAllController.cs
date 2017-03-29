using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;
using WebApplication.Infrastructure.Mappers;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class ViewAllController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAlbumService _albumService;
        private readonly IImageService _imageService;
        private readonly IExtensionService _extensionService;

        public ViewAllController(IUserService uService, IAlbumService aService, IImageService iService, IExtensionService eService)
        {
            _userService = uService;
            _albumService = aService;
            _imageService = iService;
            _extensionService = eService;
        }

        [HttpGet]
        public JsonResult GetAlbums()
        {
            var email = Membership.GetUser().UserName;
            var userId = _userService.GetUserByEmail(email).Id;

            var albums = _albumService.GetByUserId(userId).Select(album => album.Name);

            return Json(albums, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetImgs(string selectedAlbum)
        {
            var albumId = _albumService.GetAlbumId(selectedAlbum);
            var imgs = _imageService.GetAllImageEntities().Where(img => img.AlbumId == albumId);

            var resImgs = imgs.Select(img => new ImageViewModel()
            {
                Id = img.Id,
                CreationDate = img.CreationDate,
                Description = img.Description,
                ExtensionId = img.ExtensionId,
                Name = img.Name
            });
           
            return Json(resImgs, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public FileResult GetImg(int imageId)
        {
            //var albumId = _albumService.GetAlbumId(selectedAlbum);
            //var imgs = _imageService.GetAllImageEntities().Where(img => img.AlbumId == albumId);
            var img = _imageService.GetImageEntity(imageId);
            var ext = _extensionService.GetExtensionEntity(img.ExtensionId);

            return new FileContentResult(img.Picture, "image/" + ext);
            //return Json(imgs, JsonRequestBehavior.AllowGet);
        }
    }
}
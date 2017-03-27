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

        public ViewAllController(IUserService uService, IAlbumService aService, IImageService iService)
        {
            _userService = uService;
            _albumService = aService;
            _imageService = iService;
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

            //var serverPath = Server.MapPath("~");
            //var pathToImageFolder = Path.Combine(serverPath, "Content", "img");
            //var imageFiles = Directory.GetFiles(pathToImageFolder);
            //var imges = imageFiles.Select(BuildImage);
            return Json(imgs, JsonRequestBehavior.AllowGet);
        }
    }
}
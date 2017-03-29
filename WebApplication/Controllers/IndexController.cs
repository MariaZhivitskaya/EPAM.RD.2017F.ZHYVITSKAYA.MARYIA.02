using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;

namespace WebApplication.Controllers
{
    public class IndexController : Controller
    {
        private readonly ISiteDescriptionService _descriptionService;
        private readonly IUserService _userService;

        public IndexController(ISiteDescriptionService sdService, IUserService uService)
        {
            _descriptionService = sdService;
            _userService = uService;
        }
        
        [HttpGet]
        public JsonResult GetDescription()
        {
            var siteDescription = _descriptionService.GetDescriptionEntity(1);

            return Json(siteDescription.Text, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetRole()
        {
            string email = Membership.GetUser().UserName;
            var roleId = _userService.GetUserByEmail(email).RoleId;
           
            return Json(roleId, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void SetText(string text)
        {
           _descriptionService.ChangeText(1, text);
        }
    }
}
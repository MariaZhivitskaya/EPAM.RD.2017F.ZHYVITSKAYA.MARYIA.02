using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService uService)
        {
            _userService = uService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            string email = Membership.GetUser().UserName;
            var user = _userService.GetUserByEmail(email);

            var model = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                RoleId = user.RoleId
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
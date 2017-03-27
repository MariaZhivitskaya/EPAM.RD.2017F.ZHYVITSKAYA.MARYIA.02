using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;
using WebApplication.Providers;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _service;

        public AccountController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public bool Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(email, password))
                { 
                    FormsAuthentication.SetAuthCookie(email, true);
                    return true;
                }
                return false;
            }
            return false;
        }

        public void Logoff()
        {
            FormsAuthentication.SignOut();
        }

        public bool Register(string email, string password)
        {
            var anyUser = _service.GetAllUserEntities().Any(u => u.Email.Contains(email));

            if (anyUser)
            {
                return false;
            }

            if (ModelState.IsValid)
            {
                var membershipUser = ((CustomMembershipProvider)Membership.Provider)
                    .CreateUser(email, password);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(email, false);
                    return true;
                }
            }
            return false;
        }
    }
}
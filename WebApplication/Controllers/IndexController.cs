using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;

namespace WebApplication.Controllers
{
    public class IndexController : Controller
    {
        private readonly ISiteDescriptionService _descriptionService;

        public IndexController(ISiteDescriptionService sdService)
        {
            _descriptionService = sdService;
        }
        
        [HttpGet]
        public JsonResult GetDescription()
        {
            var siteDescription = _descriptionService.GetDescriptionEntity(1);

            return Json(siteDescription.Text, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public JsonResult GetRole()
        //{
        //    var siteDescription = _descriptionService.GetDescriptionEntity(1);

        //    return Json(siteDescription.Text, JsonRequestBehavior.AllowGet);
        //}
    }
}
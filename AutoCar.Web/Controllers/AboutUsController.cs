using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Web.Extensions;
using AutoCar.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoCar.Web.Controllers
{
    public class AboutUsController : BaseController
    {
        public readonly ISession _session;
        public AboutUsController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        // GET: AboutUs
        //[AdminMod]
        [AuthorizedMod]
        public ActionResult AboutUs()
        {
            var admin = System.Web.HttpContext.Current.GetMySessionObject();
            return View();
        }
    }
}
using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Web.Extensions;
using AutoCar.Web.Filters;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoCar.Web.Controllers
{
    public class AboutUsController : BaseController
    {
        // GET: AboutUs
        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult FAQs()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoCar.Web.Models;

namespace AutoCar.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            string sessionID = Session.SessionID;
            return View();
        }

    }
}
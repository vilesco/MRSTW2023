using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;
using AutoCar.Web.Models;

namespace AutoCar.Web.Controllers
{

    public class LoginController : Controller
    {
        private readonly ISession _session;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Register e)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Wellcome(Register e)
        {
            return View();
        }
    }
}
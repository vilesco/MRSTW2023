using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoCar.Web.Models;
using System.Data;


namespace AutoCar.Web.Controllers
{
    public class RegisterController : Controller
    {
        public string value = "";

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Register e)
        {
            Register user = new Register();

            return View(user);
        }
    }
}
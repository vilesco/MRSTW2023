using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Response;
using AutoCar.Domain.Entities.User;
using AutoCar.Web.Models;


namespace AutoCar.Web.Controllers
{

    public class LoginController : Controller
    {

        private readonly ISession _session;
        public LoginController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }
        // GET: Login
        public ActionResult Index()
        {
            var user = new ULoginData { Password = "Ecaterina", UserName = "catea112", LastLoginTime = DateTime.Now};

            ServiceResponse UValidate = _session.ValidateUserCredential(user);

            return View();
        }


        [HttpPost]
        public ActionResult Index(LoginData data)
        {
            ULoginData uLogin = new ULoginData
            {
                UserName = data.Username,
                Password = data.Password,
                LastLoginTime = DateTime.Now,
                IP = Request.UserHostAddress
            };

            var response = _session.ValidateUserCredential(uLogin);

            return View();
        }

        [HttpGet]
        public ActionResult Wellcome()
        {
            return View();
        }
    }
}
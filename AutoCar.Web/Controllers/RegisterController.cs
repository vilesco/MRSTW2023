using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoCar.Web.Models;
using System.Data;
using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.User;
using AutoCar.Domain.Entities.Response;

namespace AutoCar.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISession _session;

        public RegisterController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var newUser = new URegisterData { FullName = "New User",
            UserName = "Username",
            Email = "usermail@gmail.com",
            NewPassword = "password",
            ConfirmedPassword = "password",
            Terms = true,
            IP = Request.UserHostAddress,
            RegisterDateTime = DateTime.Now };

            ServiceResponse URegister = _session.ValidateUserRegister(newUser);

            return View();
        }

        

        [HttpPost]
        public ActionResult Index(RegisterData e)
        {
            RegisterData user = new RegisterData();

            return View(user);
        }
    }
}
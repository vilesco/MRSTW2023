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
            Password = "password",
            Terms = true,
            IP = Request.UserHostAddress,
            RegisterDateTime = DateTime.Now };

            ServiceResponse URegister = _session.ValidateUserRegister(newUser);

            return View();
        }

        

        [HttpPost]
        public ActionResult Index(RegisterData data)
        {
            if (ModelState.IsValid)
            {
                URegisterData newUser = new URegisterData
                {
                    Email = data.Email,
                    Password = data.Password,
                    UserName = data.UserName,
                    FullName = data.FullName,
                    Terms = data.Terms,
                };
                var response = _session.ValidateUserRegister(newUser);
                if (response.Status)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", response.StatusMessage);
                    return View();
                }

            }
            return View();
        }
    }
}
using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Response;
using AutoCar.Domain.Entities.User;
using AutoCar.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace AutoCar.Web.Controllers
{
     public class ChangePasswordController : Controller
     {
          private readonly ISession _session;
          // GET: ChangePassword
          public ChangePasswordController()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _session = bl.GetSessionBL();
               
          }
          public ActionResult Index()
          {
               var password = new UChangePasswordData { NewPassword = "NewPassword", ConfirmedPassword = "NewPassword" };
               
               if (password.NewPassword == password.ConfirmedPassword)
               {
                    var upassword = new ServiceResponse { Status = true, StatusMessage = "Password was changed succesfully!" };
                    ServiceResponse passwordsession = _session.ValidateNewPassword(password);
               }

               return View();
          }

          [HttpPost]

          public ActionResult Index(ChangePasswordData data) 
          {
               if (ModelState.IsValid)
               {
                    UChangePasswordData uChangePassword = new UChangePasswordData
                    {
                         NewPassword = data.NewPassword,
                    };

                    var response = _session.ValidateNewPassword(uChangePassword);
                    if (response.Status)
                    {
                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("Passwords are not the same!", response.StatusMessage);
                         return View();
                    }

               }
               return View();
          }
          [HttpGet]
          public ActionResult ChangePassword()
          {
               return View(new ChangePasswordData());
          }
     }

    
}
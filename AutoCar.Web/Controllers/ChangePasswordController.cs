using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Response;
using AutoCar.Domain.Entities.User;
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
          public ActionResult ChangePassword()
          {
               var password = new UChangePasswordData { NewPassword = "NewPassword", ConfirmedPassword = "NewPassword" };
               
               if (password.NewPassword == password.ConfirmedPassword)
               {
                    var upassword = new ServiceResponse { Status = true, StatusMessage = "Password was changed succesfully!" };
                    ServiceResponse passwordsession = _session.ChangePassword(password);
               }

               return View();
          }

     }
}
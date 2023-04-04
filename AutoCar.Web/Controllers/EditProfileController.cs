using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Response;
using AutoCar.Domain.Entities.User;
using AutoCar.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoCar.Web.Controllers
{
     public class EditProfileController : Controller
     {
          private readonly ISession _session;
          public EditProfileController()
          {
               var bl = new BusinessLogic.BusinessLogic();
               _session = bl.GetSessionBL();
          }
          // GET: EditProfile
          public ActionResult Index()
          {
               var user = new UEditProfileData
               {
                    FullName = "Ecaterina Popa",
                    UserName = "ecaterinast",
                    Email = "ecaterina.popa@isa.utm.md",
                    Phone = "079111000"
               };
               ServiceResponse UValidate = _session.ValidateEditProfile(user);

               return View();
          }
          [HttpPost]
          public ActionResult Index (EditProfileData data)
          {
               if (ModelState.IsValid)
               {
                    UEditProfileData uEdit = new UEditProfileData
                    {
                         FullName = data.FullName,
                         UserName = data.UserName,
                         Email = data.Email,
                         Phone = data.Phone,
                    };
                    var response = _session.ValidateEditProfile(uEdit);
                    if (response.Status)
                    {
                         return RedirectToAction("Index", "EditProfile");
                    }
               }
               return View();
          }
          [HttpGet]
          public ActionResult EditProfile()
          {
               return View(new EditProfileData());
          }
     }
}
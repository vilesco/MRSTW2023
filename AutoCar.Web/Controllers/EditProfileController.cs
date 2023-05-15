using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.User;
using AutoCar.Web.Extensions;
using AutoCar.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoCar.Web.Controllers
{
    public class EditProfileController : BaseController
    {
        private readonly ISession _session;
        public EditProfileController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }
        // GET: EditProfile
        [HttpGet]
        public ActionResult EditProfile()
        {
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            return View();
        }

        [HttpPost]
        public ActionResult EditProfile(EditProfileData data)
        {
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    UEditProfileData existingUser = new UEditProfileData
                    {
                        Id = user.Id,
                        Email = data.Email,
                        UserName = data.UserName,
                        PhoneNumber = data.PhoneNumber,
                        FullName = data.FullName

                    };
                    var response = _session.EditProfileAction(existingUser);
                    if (response.Status)
                    {
                        return RedirectToAction("Dashboard", "Dashboard", existingUser);
                    }
                    else
                    {
                        ModelState.AddModelError("", response.StatusMessage);
                        return View(data);
                    }
                }

            }
            return View();

        }

    }
}
using AutoCar.BusinessLogic.Interfaces;
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
          public ActionResult EditProfile()
        {
            return View();
        }
    }
}
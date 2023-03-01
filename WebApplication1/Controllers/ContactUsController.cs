using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: contact_us
        public ActionResult ContactUs()
        {
            return View();
        }
    }
}
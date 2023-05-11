﻿using AutoCar.Domain.Entities.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoCar.Web.Controllers
{
    public class ListingController : Controller
    {
        // GET: Listing
        public ActionResult Listing()
        {
            List<PostMinimal> modelList = TempData["modelList"] as List<PostMinimal>;
            return View(modelList);
        }

    }
}
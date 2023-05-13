﻿using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Post;
using AutoCar.Web.Extensions;
using AutoCar.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace AutoCar.Web.Controllers
{
    public class EditPostController : BaseController
    {
        private readonly ISession _session;
        private readonly IPost _post;
        public EditPostController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
            _post = bl.GetPostBL();
        }

        [HttpGet]
        public ActionResult EditPost(int PostId)
        {
            var model = _post.GetById(PostId);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditPost(PostData postData)
        {
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    PDbModel newPost = new PDbModel
                    {
                        Model = postData.Model,
                        Type = postData.Type,
                        Make = postData.Make,
                        Year = postData.Year,
                        Transmission = postData.Transmission,
                        Color = postData.Color,
                        EngineCapacity = postData.EngineCapacity,
                        Millage = postData.Millage,
                        Fuel = postData.Fuel,
                        ABS = postData.ABS,
                        AC = postData.AC,
                        CruiseControl = postData.CruiseControl,
                        KeylessEntry = postData.KeylessEntry,
                        AirBags = postData.AirBags,
                        PowerWindows = postData.PowerWindows,
                        Price = postData.Price,
                        Location = postData.Location,
                        Comment = postData.Comment,
                        ImagePath = postData.ImagePath,
                        DateAdded = DateTime.Now,
                        Author = user.Username
                    };

                    _post.Update(newPost);
                    return RedirectToAction("Detail", "Detail");
                }
            }
            return View();
        }
    }
}
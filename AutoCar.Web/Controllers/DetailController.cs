using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace AutoCar.Web.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail

        private readonly IPost _post;
        private readonly ISession _session;
        public DetailController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _post = bl.GetPostBL();
        }
         
        [HttpGet]
        public ActionResult Detail(int PostID)
        {
            var data = _post.GetById(PostID);
            var model = new PostData
            {
                Id = data.Id,
                Model = data.Model,
                Type = data.Type,
                Make = data.Make,
                Year = data.Year,
                Transmission = data.Transmission,
                Color = data.Color,
                EngineCapacity = data.EngineCapacity,
                Millage = data.Millage,
                Fuel = data.Fuel,
                ABS = data.ABS,
                AC = data.AC,
                CruiseControl = data.CruiseControl,
                KeylessEntry = data.KeylessEntry,
                AirBags = data.AirBags,
                PowerWindows = data.PowerWindows,
                Price = data.Price,
                Location = data.Location,
                Comment = data.Comment,
                ImagePath = data.ImagePath,
                DateAdded = data.DateAdded,
                Author = data.Author
            };
            var relatedPosts = _post.GetPostsByMakeOrLocation(model.Make).Concat(_post.GetPostsByMakeOrLocation(model.Location)).ToList();
            var posts = relatedPosts.Where(x => x.Id != model.Id).ToList();
            //relatedPosts = relatedPosts.Where(x => x.Id != model.Id).ToList();
            ViewBag.RelatedPosts = posts;
            return View(model);
        }
    }
}
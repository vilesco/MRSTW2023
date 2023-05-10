using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoCar.Web.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail

        private readonly IPost _post;
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
                Image = data.Image,
                //DateAdded = data.DateAdded,
                //Author = data.Author
            };
            return View(model);
        }
    }
}
using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoCar.Web.Controllers
{
    public class ListingController : Controller
    {
        private readonly IPost _post;
        public ListingController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _post = bl.GetPostBL();
        }
        // GET: Listing
        public ActionResult ListingSearch()
        {
            if (TempData["modelList"] is List<PostMinimal> modelList)
            {
                return View(modelList);
            }
            else
            {
                return RedirectToAction("NotFound");
            }
        }

        [HttpGet]
        public ActionResult Listing()
        {
            var data = _post.GetAll();
            List<PostMinimal> allPosts = new List<PostMinimal>();
            foreach (var post in data)
            {
                var postMinimal = new PostMinimal();
                postMinimal.Id = post.Id;
                postMinimal.Fuel = post.Fuel;
                postMinimal.Year = post.Year;
                postMinimal.Transmission = post.Transmission;
                postMinimal.Price = post.Price;
                postMinimal.DateAdded = post.DateAdded;
                postMinimal.Millage = post.Millage;
                postMinimal.Model = post.Model;
                postMinimal.Make = post.Make;
                postMinimal.Location = post.Location;
                postMinimal.ImagePath = post.ImagePath;
                postMinimal.EngineCapacity = post.EngineCapacity;
                allPosts.Add(postMinimal);
            }
            return View(allPosts);
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}
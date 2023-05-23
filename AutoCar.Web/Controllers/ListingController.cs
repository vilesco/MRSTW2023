using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Post;
using Microsoft.Ajax.Utilities;
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
        //[HttpPost]
        public ActionResult ListingSearchWrap()
        {
            var posts = (List<PostMinimal>)TempData["modelList"];
            if (posts.Count() > 0)
            {

                return View(posts);
            }
            else
            {
                return RedirectToAction("NotFound");
            }
        }
        [HttpGet]
        public ActionResult ListingSearch(string Make, string Location)
        {
            if (Make != null)
            {
                var data = _post.GetPostsByMakeOrLocation(Make);
                if (data.Count() > 0)
                {
                    TempData["postsByMake"] = data;
                    return RedirectToAction("Listing");
                }
                else return RedirectToAction("NotFound");
            }
            if (Location != null)
            {
                var data = _post.GetPostsByMakeOrLocation(Location);
                if (data.Count() > 0)
                {
                    TempData["postsByLocation"] = data;
                    return RedirectToAction("Listing");
                }
                else return RedirectToAction("NotFound");
            }
            return RedirectToAction("Listing");
        }

        [HttpGet]
        public ActionResult Listing()
        {
            var postsBySearchWrap = TempData["foundPosts"] as List<PostMinimal>;
            if (postsBySearchWrap != null && postsBySearchWrap.Count() > 0) { return View(postsBySearchWrap); }
            var postsByType = TempData["postsListByType"] as List<PostMinimal>;
            if (postsByType != null && postsByType.Count() > 0) { return View(postsByType); }
            var postsByMake = TempData["postsByMake"] as List<PostMinimal>;
            if (postsByType != null && postsByMake.Count() > 0) { return View(postsByMake); }
            var postsByLocation = TempData["postsByLocation"] as List<PostMinimal>;
            if (postsByLocation != null && postsByLocation.Count() > 0) { return View(postsByLocation); }
            var data = _post.GetAll();
            List<PostMinimal> allPosts = new List<PostMinimal>();
            foreach (var post in data)
            {
                var postMinimal = new PostMinimal
                {
                    Id = post.Id,
                    Fuel = post.Fuel,
                    Year = post.Year,
                    Transmission = post.Transmission,
                    Price = post.Price,
                    DateAdded = post.DateAdded,
                    Millage = post.Millage,
                    Model = post.Model,
                    Make = post.Make,
                    Location = post.Location,
                    ImagePath = post.ImagePath,
                    EngineCapacity = post.EngineCapacity
                };
                allPosts.Add(postMinimal);
            }
            return View(allPosts);
        }

        [HttpGet]
        public ActionResult ListingByType(string type)
        {
            var data = _post.GetPostsByType(type);
            List<PostMinimal> posts = new List<PostMinimal>();
            foreach (var post in data)
            {
                var postMinimal = new PostMinimal
                {
                    Id = post.Id,
                    Fuel = post.Fuel,
                    Year = post.Year,
                    Transmission = post.Transmission,
                    Price = post.Price,
                    DateAdded = post.DateAdded,
                    Millage = post.Millage,
                    Model = post.Model,
                    Make = post.Make,
                    Location = post.Location,
                    ImagePath = post.ImagePath,
                    EngineCapacity = post.EngineCapacity
                };
                posts.Add(postMinimal);
            }
            TempData["postsListByType"] = posts;
            return RedirectToAction("Listing");
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}
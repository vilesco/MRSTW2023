using AutoCar.BusinessLogic.DBModel;
using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Post;
using AutoCar.Web.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoCar.Web.Controllers
{
    public class ListingController : BaseController
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
            if (posts.Any())
            {
                return RedirectToAction("ListingParameters");
            }
            return RedirectToAction("ListingParameters");
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
                    return RedirectToAction("ListingParameters");
                }
            }
            if (Location != null)
            {
                var data = _post.GetPostsByMakeOrLocation(Location);
                if (data.Any())
                {
                    TempData["postsByLocation"] = data;
                    return RedirectToAction("ListingParameters");
                }
            }
            return RedirectToAction("ListingParameters");
        }

        //[HttpGet]
        public ActionResult ListingParameters()
        {
            var model = new ListingPageData();
            var sideBar = new SideBarData();
            using (var db = new PostContext())
            {
                var years = db.Posts.Select(a => a.Year).Distinct().ToList();
                var makes = db.Posts.Select(a => a.Make).Distinct().ToList();
                var prices = db.Posts.Select(a => a.Price).Distinct().ToList();
                var locations = db.Posts.Select(a => a.Location).Distinct().ToList();
                sideBar.LocationList = locations;
                sideBar.MakeList = makes;
                sideBar.PriceRange = prices;
                sideBar.YearRange = years;
            }
            model.SideBar = sideBar;
            if (TempData["foundPosts"] is List<PostMinimal> postsBySearchWrap && postsBySearchWrap.Any())
            {
                model.ListingItems = postsBySearchWrap;
                return View(model);
            }
            else if (TempData["postsListByType"] is List<PostMinimal> postsByType && postsByType.Any())
            {
                model.ListingItems = postsByType;
                return View(model);
            }
            else if (TempData["postsByMake"] is List<PostMinimal> postsByMake && postsByMake.Any())
            {
                model.ListingItems = postsByMake;
                return View(model);
            }
            else if (TempData["postsByLocation"] is List<PostMinimal> postsByLocation && postsByLocation.Any())
            {
                model.ListingItems = postsByLocation;
                return View(model);
            }
            else if (TempData["postsByFilter"] is List<PostMinimal> postsByFilter && postsByFilter.Any())
            {
                model.ListingItems = postsByFilter;
                return View(model);
            }
            if (model.ListingItems == null) return View(model);
            
            return View(model);
        }
        public ActionResult Listing()
        {
            var model = new ListingPageData();
            var sideBar = new SideBarData();
            using (var db = new PostContext())
            {
                var years = db.Posts.Select(a => a.Year).Distinct().ToList();
                var makes = db.Posts.Select(a => a.Make).Distinct().ToList();
                var prices = db.Posts.Select(a => a.Price).Distinct().ToList();
                var locations = db.Posts.Select(a => a.Location).Distinct().ToList();
                sideBar.LocationList = locations;
                sideBar.MakeList = makes;
                sideBar.PriceRange = prices;
                sideBar.YearRange = years;
            }
            model.SideBar = sideBar;
            var data = _post.GetAll();
            model.ListingItems = data.Select(post => new PostMinimal
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
            }).ToList();

            return View(model);
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
            return RedirectToAction("ListingParameters");
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Sidebar(ListingPageData data)
        {
            var filter = new PListingFilterData()
            {
                KeyWord = data.SideBar.KeyWord,
                MinPrice = data.SideBar.MinPrice,
                MaxPrice = data.SideBar.MaxPrice,
                Location = data.SideBar.Location,
                Make = data.SideBar.Make,
                MaxYear = data.SideBar.MaxYear,
                MinYear = data.SideBar.MinYear,
                Type = data.SideBar.Type,
                Transmission = data.SideBar.Transmission,
                Fuel = data.SideBar.Fuel
            };
            TempData["postsByFilter"] = _post.GetPostsByListingFilter(filter);
            return RedirectToAction("ListingParameters");
        }
    }
}
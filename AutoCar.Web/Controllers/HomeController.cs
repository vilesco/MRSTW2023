using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;
using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Post;
using AutoCar.Web.Extensions;
using AutoCar.Web.Filters;
using AutoCar.Web.Models;

namespace AutoCar.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPost _post;
        public HomeController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _post = bl.GetPostBL();
        }
        //[AuthorizedMod]
        [LatestPosts]
        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }
        //[AuthorizedMod]
        [LatestPosts]
        //[AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)] 
        [HttpGet]
        public ActionResult Index(SearchWrapData searchWrapData)
        {
            if (searchWrapData.MakeOrModel != null)
            {
                PSearchWrapData data = new PSearchWrapData
                {
                    MakeOrModel = searchWrapData.MakeOrModel,
                    PriceRange = searchWrapData.PriceRange,
                    Location = searchWrapData.Location
                };
                var results = _post.GetBySearchWrapData(data);
                if (results.Count() > 0)
                {
                    TempData["modelList"] = results;
                    return RedirectToAction("ListingSearchWrap", "Listing");
                }
                else
                {
                    return RedirectToAction("NotFound", "Listing");
                }
            }
            else
            {
                return View();
            }
        }
    }
}
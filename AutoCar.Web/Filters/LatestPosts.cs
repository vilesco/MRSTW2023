using AutoCar.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoCar.Web.Filters
{
    public class LatestPostsAttribute : ActionFilterAttribute
    {
        private IPost _post;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var bl = new BusinessLogic.BusinessLogic();
            _post = bl.GetPostBL();
            var latestRecords = _post.GetLatestPosts();

            filterContext.Controller.ViewBag.LatestRecords = latestRecords;
        }
    }
}
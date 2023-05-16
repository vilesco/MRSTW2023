using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutoCar.Web.Filters
{
    public class AuthenticationStatus : ActionFilterAttribute
    {
        private readonly ISession _session;
        public AuthenticationStatus()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var apiCookie = HttpContext.Current.Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var user = _session.GetUserByCookie(apiCookie.Value);
                if (user != null)
                {
                    HttpContext.Current.SetMySessionObject(user);
                    filterContext.Controller.TempData["AuthenticatedUser"] = user;
                    base.OnActionExecuting(filterContext);
                }
            }
        }
    }
}
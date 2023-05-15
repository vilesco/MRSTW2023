using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.User;
using AutoCar.Web.Extensions;
using AutoCar.Web.Filters;
using AutoCar.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoCar.Web.Controllers
{
    public class DashboardController : BaseController
    {
        public readonly ISession _session;
        public readonly IPost _post;
        public DashboardController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
            _post = bl.GetPostBL();
        }
        [AuthorizedMod]
        public ActionResult Dashboard()
        {
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            var userData = _session.GetUserById(user.Id);
            if (user != null)
            {
                var userModel = new UserData()
                {
                    Id = userData.Id,
                    PhoneNumber = userData.PhoneNumber,
                    Username = userData.UserName,
                    FullName = userData.FullName,
                    Email = user.Email
                };
                return View(userModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [AuthorizedMod]
        [HttpGet]
        public ActionResult EditProfile(int? userId)
        {
            var userData = _session.GetUserById((int)userId);
            if (userData != null)
            {
                var userModel = new UserData()
                {
                    Id = userData.Id,
                    PhoneNumber = userData.PhoneNumber,
                    Username = userData.UserName,
                    FullName = userData.FullName,
                    Email = userData.Email
                };
                return View(userModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [AuthorizedMod]
        [HttpPost]
        public ActionResult EditProfile(UserData data)
        {
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    UEditProfileData existingUser = new UEditProfileData
                    {
                        Id = user.Id,
                        Email = data.Email,
                        //UserName = data.Username,
                        PhoneNumber = data.PhoneNumber,
                        FullName = data.FullName

                    };
                    var response = _session.EditProfileAction(existingUser);
                    if (response.Status)
                    {
                        return RedirectToAction("Dashboard", "Dashboard", existingUser);
                    }
                    else
                    {
                        ModelState.AddModelError("", response.StatusMessage);
                        return View(data);
                    }
                }
            }
            return View();
        }
        [AuthorizedMod]
        [HttpGet]
        public ActionResult ActivePosts(int? userId)
        {
            if (_session.GetUserById((int)userId) != null)
            {
                var posts = _post.GetPostsByAuthor(_session.GetUserById((int)userId).UserName);
                if (posts.Count() > 0)
                {
                    ViewBag.ActivePosts = posts;
                    return View();
                }
            }
            return View();
        }
        [AuthorizedMod]
        [HttpPost]
        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}
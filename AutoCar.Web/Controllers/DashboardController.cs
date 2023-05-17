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
        private readonly UserMinimal userAuthenticated;

        public DashboardController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
            _post = bl.GetPostBL();
            //SessionStatus();
            userAuthenticated = System.Web.HttpContext.Current.GetMySessionObject();
        }
        [AuthorizedMod]
        public ActionResult Dashboard()
        {
            //SessionStatus();
            //var user = System.Web.HttpContext.Current.GetMySessionObject();
            var userData = _session.GetUserById(userAuthenticated.Id);
            if (userAuthenticated != null)
            {
                var userModel = new UserData()
                {
                    Id = userData.Id,
                    PhoneNumber = userData.PhoneNumber,
                    Username = userData.UserName,
                    FullName = userData.FullName,
                    Email = userAuthenticated.Email
                };
                return View(userModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [AuthorizedMod]
        public ActionResult EditProfile()
        {
            var userModel = new UserData();
            return View(userModel);
        }
        [AuthorizedMod]
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult EditProfile(int? userId)
        {
            if ((int)userId != userAuthenticated.Id) return View();
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
            //SessionStatus();
            //var user = System.Web.HttpContext.Current.GetMySessionObject();
            if (userAuthenticated != null && data.Id == userAuthenticated.Id)
            {
                if (ModelState.IsValid)
                {
                    UEditProfileData existingUser = new UEditProfileData
                    {
                        Id = userAuthenticated.Id,
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
        public ActionResult ActivePosts()
        {
            var userModel = new UserData();
            return View(userModel);
        }
        [AuthorizedMod]
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult ActivePosts(int? userId)
        {
            if (userAuthenticated.Id == (int)userId && userId != null)
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
        public ActionResult ChangePassword()
        {
            var model = new UChangePasswordData();
            return View(model);
        }
        [AuthorizedMod]
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult ChangePassword(int? userId)
        {
            if(userId == null) return View();
            var model = new UChangePasswordData()
            {
                Id = (int)userId
            };
            return View(model);
        }
        [AuthorizedMod]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(UChangePasswordData password)
        {
            var model = new UChangePasswordData();
            if (ModelState.IsValid)
            {
                if (password.NewPassword == password.ConfirmedPassword && userAuthenticated.Id == password.Id)
                {
                    var response = _session.ChangePassword(password);
                    if (response.Status)
                    {
                        ViewBag.ConfirmationMessage = response.StatusMessage;
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Confirmation failed! Try again";
                    return View(model);
                }
            }
            return View();
        }
        //[ValidateAntiForgeryToken]
        [AuthorizedMod]
        //[HttpPost]
        public ActionResult UserLogout()
        {
            Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
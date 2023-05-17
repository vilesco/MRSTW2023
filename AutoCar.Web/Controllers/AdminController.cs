using AutoCar.BusinessLogic.DBModel;
using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Post;
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
    [AdminMod]
    public class AdminController : BaseController
    {
        public readonly ISession _session;
        public readonly IPost _post;
        private readonly UserMinimal adminAuthenticated;
        public AdminController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
            _post = bl.GetPostBL();
            adminAuthenticated = System.Web.HttpContext.Current.GetMySessionObject();
        }

        public ActionResult Dashboard()
        {
            var userData = _session.GetUserById(adminAuthenticated.Id);
            if (adminAuthenticated != null)
            {
                var userModel = new UserData()
                {
                    Id = userData.Id,
                    PhoneNumber = userData.PhoneNumber,
                    Username = userData.UserName,
                    FullName = userData.FullName,
                    Email = adminAuthenticated.Email
                };
                return View(userModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Users()
        {
            var users = _session.GetAll();
            List<UserData> allUsers = new List<UserData>();
            foreach(var user in users)
            {
                var userData = new UserData();
                userData.Id = user.Id;
                userData.Username = user.UserName;
                userData.AccessLevel = user.AccessLevel;
                userData.Email = user.Email;
                userData.FullName = user.FullName;
                allUsers.Add(userData);
            }
            return View(allUsers);
        }
        //[HttpGet]
        public ActionResult EditUser(int? userId)
        {
            if (userId == null) return View();
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

        [HttpPost]
        public ActionResult EditUser(UserData data)
        {
            //SessionStatus();
            //var user = System.Web.HttpContext.Current.GetMySessionObject();
            
                if (ModelState.IsValid)
                {
                    UEditProfileData existingUser = new UEditProfileData
                    {
                        Id = data.Id,
                        Email = data.Email,
                        PhoneNumber = data.PhoneNumber,
                        FullName = data.FullName

                    };
                    var response = _session.EditProfileAction(existingUser);
                    if (response.Status)
                    {
                        return RedirectToAction("Users");
                    }
                    else
                    {
                        ModelState.AddModelError("", response.StatusMessage);
                        return View(data);
                    }
                }
            return View();
        }

        public ActionResult DeleteUser(int? userId)
        {
            using (var db = new UserContext())
            {
                var userToDelete = db.Users.Find((int)userId);
                if (userToDelete == null)
                {
                    return HttpNotFound();
                }
                db.Users.Remove(userToDelete);
                db.SaveChanges();
                return RedirectToAction("Users");
            }
        }

        public ActionResult Posts()
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

        public ActionResult DeletePost(int? postId)
        {
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            var postToDelete = _post.GetById((int)postId);
            if (postToDelete == null && user.Username == postToDelete.Author)
            {
                return HttpNotFound();
            }
            else
            {
                _post.Delete((int)postId);
                _post.Save();
                return RedirectToAction("Posts", "Admin");
            }
        }
    }
}
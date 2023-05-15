using AutoCar.BusinessLogic.DBModel;
using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Post;
using AutoCar.Web.Extensions;
using AutoCar.Web.Filters;
using AutoCar.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace AutoCar.Web.Controllers
{
    public class PostController : BaseController
    {
        private readonly ISession _session;
        private readonly IPost _post;
        public PostController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
            _post = bl.GetPostBL();
        }
        public ActionResult AddPost()
        {
            return View();
        }

        //[AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        [HttpPost]
        public ActionResult AddPost(PostData postData)
        {
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    string fileName = Path.GetFileNameWithoutExtension(postData.Image.FileName);
                    string extension = Path.GetExtension(postData.Image.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    postData.ImagePath = "~/Content/PostsImages/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Content/PostsImages/"), fileName);
                    postData.Image.SaveAs(fileName);
                    PDbModel newPost = new PDbModel
                    {
                        Model = postData.Model,
                        Type = postData.Type,
                        Make = postData.Make,
                        Year = postData.Year,
                        Transmission = postData.Transmission,
                        Color = postData.Color,
                        EngineCapacity = postData.EngineCapacity,
                        Millage = postData.Millage,
                        Fuel = postData.Fuel,
                        ABS = postData.ABS,
                        AC = postData.AC,
                        CruiseControl = postData.CruiseControl,
                        KeylessEntry = postData.KeylessEntry,
                        AirBags = postData.AirBags,
                        PowerWindows = postData.PowerWindows,
                        Price = postData.Price,
                        Location = postData.Location,
                        Comment = postData.Comment,
                        ImagePath = postData.ImagePath,
                        DateAdded = DateTime.Now,
                        Author = user.Username
                    };

                    var response = _post.AddPostAction(newPost);
                    if (response.Status)
                    {
                        return RedirectToAction("Detail", "Post", new { PostID = newPost.Id });
                    }
                    else
                    {
                        ModelState.AddModelError("", response.StatusMessage);
                        return View(postData);
                    }
                }
            }

            return View();
        }
        public ActionResult EditPost()
        {
            var post = new PostData();
            return View(post);
        }
        [HttpGet]
        public ActionResult EditPost(int? postId)
        {
            var postToEdit = _post.GetById((int)postId);
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    PostData postModel = new PostData
                    {
                        Id = postToEdit.Id,
                        Model = postToEdit.Model,
                        Type = postToEdit.Type,
                        Make = postToEdit.Make,
                        Year = postToEdit.Year,
                        Transmission = postToEdit.Transmission,
                        Color = postToEdit.Color,
                        EngineCapacity = postToEdit.EngineCapacity,
                        Millage = postToEdit.Millage,
                        Fuel = postToEdit.Fuel,
                        ABS = postToEdit.ABS,
                        AC = postToEdit.AC,
                        CruiseControl = postToEdit.CruiseControl,
                        KeylessEntry = postToEdit.KeylessEntry,
                        AirBags = postToEdit.AirBags,
                        PowerWindows = postToEdit.PowerWindows,
                        Price = postToEdit.Price,
                        Location = postToEdit.Location,
                        Comment = postToEdit.Comment,
                        ImagePath = postToEdit.ImagePath,
                        DateAdded = DateTime.Now,
                        Author = user.Username
                    };
                    //_post.Update(newPost);
                    return View(postModel);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult EditPost(PostData postToEdit)
        {
            if (ModelState.IsValid)
            {
                using (var db = new PostContext())
                {
                    string fileName = Path.GetFileNameWithoutExtension(postToEdit.Image.FileName);
                    string extension = Path.GetExtension(postToEdit.Image.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    postToEdit.ImagePath = "~/Content/PostsImages/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Content/PostsImages/"), fileName);
                    postToEdit.Image.SaveAs(fileName);
                    var post = db.Posts.Find(postToEdit.Id);
                    if (post != null)
                    {
                        post.Id = postToEdit.Id;
                        post.Model = postToEdit.Model;
                        post.Type = postToEdit.Type;
                        post.Make = postToEdit.Make;
                        post.Year = postToEdit.Year;
                        post.Transmission = postToEdit.Transmission;
                        post.Color = postToEdit.Color;
                        post.EngineCapacity = postToEdit.EngineCapacity;
                        post.Millage = postToEdit.Millage;
                        post.Fuel = postToEdit.Fuel;
                        post.ABS = postToEdit.ABS;
                        post.AC = postToEdit.AC;
                        post.CruiseControl = postToEdit.CruiseControl;
                        post.KeylessEntry = postToEdit.KeylessEntry;
                        post.AirBags = postToEdit.AirBags;
                        post.PowerWindows = postToEdit.PowerWindows;
                        post.Price = postToEdit.Price;
                        post.Location = postToEdit.Location;
                        post.Comment = postToEdit.Comment;
                        post.ImagePath = postToEdit.ImagePath;
                        post.DateAdded = DateTime.Now;
                        post.Author = postToEdit.Author;
                        //db.SaveChanges();
                    }
                    //_post.Update(post);
                    db.SaveChanges();
                    return RedirectToAction("Detail", new { postId = post.Id });
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Detail(int postID)
        {
            var data = _post.GetById(postID);
            var model = new PostData
            {
                Id = data.Id,
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
                ImagePath = data.ImagePath,
                DateAdded = data.DateAdded,
                Author = data.Author
            };
            var relatedPosts = _post.GetPostsByMakeOrLocation(model.Make).Concat(_post.GetPostsByMakeOrLocation(model.Location)).ToList();
            var posts = relatedPosts.Where(x => x.Id != model.Id).ToList();
            //relatedPosts = relatedPosts.Where(x => x.Id != model.Id).ToList();
            ViewBag.RelatedPosts = posts;
            return View(model);
        }
        //[HttpPost]
        [AuthorizedMod]
        public ActionResult Delete(int? postId)
        {
            var postToDelete = _post.GetById((int)postId);
            if (postToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                _post.Delete((int)postId);
                _post.Save();
                return RedirectToAction("Dashboard", "Dashboard");
            }
        }
    }
}
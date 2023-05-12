using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Post;
using AutoCar.Web.Extensions;
using AutoCar.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoCar.Web.Controllers
{
    public class AddPostController : BaseController
    {
        private readonly ISession _session;
        private readonly IPost _post;
        public AddPostController()
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
                        return RedirectToAction("Detail", "Detail", new {PostID = newPost.Id});
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
    }
}
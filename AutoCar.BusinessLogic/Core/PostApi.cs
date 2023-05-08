using AutoCar.BusinessLogic.DBModel;
using AutoCar.Domain.Entities.Post;
using AutoCar.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.BusinessLogic.Core
{
    public class PostApi
    {
        public ServiceResponse AddPost(PDbModel newPost)
        {
            var response = new ServiceResponse();
            try
            {   
                using (var db = new PostContext())
                {
                    db.Posts.Add(newPost);
                    db.SaveChanges();
                }
                response.StatusMessage = "Post added successfully!";
                response.Status = true;
            }
            catch
            {
                response.StatusMessage = "An error occured while adding post";
                response.Status = false;
            }
            return response;
        }
    }
}

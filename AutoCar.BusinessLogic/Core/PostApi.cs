using AutoCar.BusinessLogic.DBModel;
using AutoCar.Domain.Entities.Post;
using AutoCar.Domain.Entities.Response;
using AutoCar.Domain.Entities.User;
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

        public IEnumerable<PostMinimal> ReturnPostsBySearchWrapData(PSearchWrapData searchWrapData)
        {
            List<PostMinimal> list = new List<PostMinimal>();
            using (var db = new PostContext())
            {
                var results = db.Posts.Where(i => i.Make.Contains(searchWrapData.MakeOrModel) || i.Model.Contains(searchWrapData.MakeOrModel));
                if (!string.IsNullOrEmpty(searchWrapData.PriceRange))
                {
                    var range = searchWrapData.PriceRange.Split('-');
                    int minPrice = int.Parse(range[0]);
                    int maxPrice = range.Length > 1 ? int.Parse(range[1]) : int.MaxValue;
                    results = results.Where(i => i.Price >= minPrice && i.Price < maxPrice);
                }
                if (!string.IsNullOrEmpty(searchWrapData.Location))
                {
                    results = results.Where(i => i.Location.Contains(searchWrapData.Location));
                }
                //var postMinimal = new PostMinimal();
                
                foreach (var item in results)
                {
                    var postMinimal = new PostMinimal
                    {
                        Id = item.Id,
                        Transmission = item.Transmission,
                        Location = item.Location,
                        Price = item.Price,
                        Year = item.Year,
                        DateAdded = item.DateAdded,
                        EngineCapacity = item.EngineCapacity,
                        Fuel = item.Fuel,
                        Make = item.Make,
                        Model = item.Model,
                        Millage = item.Millage,
                        ImagePath = item.ImagePath
                    };
                    list.Add(postMinimal);
                }
            }
            return list.ToList();
        }
        
        public IEnumerable<PostMinimal> ReturnLatestPosts()
        {
            List<PostMinimal> list = new List<PostMinimal>();
            using (var db = new PostContext())
            {
                var results = db.Posts.OrderByDescending(x => x.DateAdded).Take(4).ToList();
                foreach(var item in results)
                {
                    var postMinimal = new PostMinimal
                    {
                        Id = item.Id,
                        Transmission = item.Transmission,
                        Location = item.Location,
                        Price = item.Price,
                        Year = item.Year,
                        DateAdded = item.DateAdded,
                        EngineCapacity = item.EngineCapacity,
                        Fuel = item.Fuel,
                        Make = item.Make,
                        Model = item.Model,
                        Millage = item.Millage,
                        ImagePath = item.ImagePath
                    };
                    list.Add(postMinimal);
                }
            }
            return list.ToList();
        }

        public IEnumerable<PostMinimal> ReturnPostsByMakeOrLocation(string MakeOrLocation)
        {
            List<PostMinimal> list = new List<PostMinimal>();
            using (var db = new PostContext())
            {
                var results = db.Posts.Where(i => i.Make.Contains(MakeOrLocation) || i.Location.Contains(MakeOrLocation));
                foreach (var item in results)
                {
                    var postMinimal = new PostMinimal
                    {
                        Id = item.Id,
                        Transmission = item.Transmission,
                        Location = item.Location,
                        Price = item.Price,
                        Year = item.Year,
                        DateAdded = item.DateAdded,
                        EngineCapacity = item.EngineCapacity,
                        Fuel = item.Fuel,
                        Make = item.Make,
                        Model = item.Model,
                        Millage = item.Millage,
                        ImagePath = item.ImagePath
                    };
                    list.Add(postMinimal);
                }
            }
            return list.ToList();
        }
        public IEnumerable<PostMinimal> ReturnPostsByAuthor(string author)
        {
            List<PostMinimal> list = new List<PostMinimal>();
            using (var db = new PostContext())
            {
                var results = db.Posts.Where(a => a.Author.Contains(author));
                foreach (var item in results)
                {
                    var postMinimal = new PostMinimal
                    {
                        Id = item.Id,
                        Transmission = item.Transmission,
                        Location = item.Location,
                        Price = item.Price,
                        Year = item.Year,
                        DateAdded = item.DateAdded,
                        EngineCapacity = item.EngineCapacity,
                        Fuel = item.Fuel,
                        Make = item.Make,
                        Model = item.Model,
                        Millage = item.Millage,
                        ImagePath = item.ImagePath
                    };
                    list.Add(postMinimal);
                }
            }
            return list.ToList();
        }
    }
}

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
            try
            {
                using (var db = new PostContext())
                {
                    var results = db.Posts.OrderByDescending(x => x.DateAdded).Take(4).ToList();
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
            catch
            {
                return null;
            }
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
        public IEnumerable<PostMinimal> ReturnPostsByType(string type)
        {
            List<PostMinimal> list = new List<PostMinimal>();
            using (var db = new PostContext())
            {
                var results = db.Posts.Where(a => a.Type.Contains(type));
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
        public IEnumerable<PostMinimal> ReturnPostsByListingFilter(PListingFilterData filter)
        {
            List<PostMinimal> list = new List<PostMinimal>();
            using (var db = new PostContext())
            {
                var query = db.Posts.AsQueryable();

                if (!string.IsNullOrEmpty(filter.KeyWord))
                {
                    query = query.Where(c => c.Make.Contains(filter.KeyWord) || c.Model.Contains(filter.KeyWord));
                }

                if (filter.MinPrice > 0 || filter.MaxPrice > 0)
                {
                    query = query.Where(c => c.Price >= filter.MinPrice && c.Price <= filter.MaxPrice);
                }

                if (!string.IsNullOrEmpty(filter.Location) && filter.Location != "Not specified")
                {
                    query = query.Where(c => c.Location.Equals(filter.Location));
                }

                if (filter.MinYear > 0 || filter.MaxYear > 0)
                {
                    query = query.Where(c => c.Year >= filter.MinYear && c.Year <= filter.MaxYear);
                }

                if (!string.IsNullOrEmpty(filter.Type) && filter.Type != "Not specified")
                {
                    query = query.Where(c => c.Type.Equals(filter.Type));
                }

                if (!string.IsNullOrEmpty(filter.Make) && filter.Make != "Not specified")
                {
                    query = query.Where(c => c.Make.Equals(filter.Make));
                }

                if (!string.IsNullOrEmpty(filter.Transmission) && filter.Transmission != "Not specified")
                {
                    query = query.Where(c => c.Transmission.Equals(filter.Transmission));
                }

                if (!string.IsNullOrEmpty(filter.Fuel) && filter.Fuel != "Not specified")
                {
                    query = query.Where(c => c.Fuel.Equals(filter.Fuel));
                }

                var results = query.ToList();

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

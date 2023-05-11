using AutoCar.BusinessLogic.Core;
using AutoCar.BusinessLogic.DBModel;
using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Post;
using AutoCar.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.BusinessLogic
{
    public class PostBL : PostApi, IPost
    {
        private readonly PostContext _context;
        public PostBL()
        {
            _context = new PostContext();
        }
        public PostBL(PostContext context)
        {
            _context = context;
        }
        public ServiceResponse AddPostAction(PDbModel model)
        {
            return AddPost(model);
        }

        public PDbModel GetById(int PostID)
        {
            return _context.Posts.Find(PostID);
        }

        public IEnumerable<PDbModel> GetAll()
        {
            return _context.Posts.ToList();
        }
        public IEnumerable<PostMinimal> GetBySearchWrapData(PSearchWrapData searchWrapData)
        {
            var results = _context.Posts.Where(i => i.Make.Contains(searchWrapData.MakeOrModel) || i.Model.Contains(searchWrapData.MakeOrModel));
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
            List<PostMinimal> list = new List<PostMinimal>();
            foreach(var item in results)
            {
                var postMinimal = new PostMinimal();
                postMinimal.Id = item.Id;
                postMinimal.Transmission = item.Transmission;
                postMinimal.Location = item.Location;
                postMinimal.Price = item.Price;
                postMinimal.Year = item.Year;
                postMinimal.DateAdded = item.DateAdded;
                postMinimal.EngineCapacity = item.EngineCapacity;
                postMinimal.Fuel = item.Fuel;
                postMinimal.Make = item.Make;
                postMinimal.Model = item.Model;
                postMinimal.Millage = item.Millage;
                list.Add(postMinimal);
            }
            return list.ToList();
        }

        public void Update(PDbModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
        public void Delete(int PostID)
        {
            PDbModel model = _context.Posts.Find(PostID);
            if (model != null)
            {
                _context.Posts.Remove(model);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

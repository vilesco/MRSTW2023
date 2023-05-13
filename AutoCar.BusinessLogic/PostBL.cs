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
            return ReturnPostsBySearchWrapData(searchWrapData);
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
        public IEnumerable<PostMinimal> GetLatestPosts()
        {
            return (IEnumerable<PostMinimal>)_context.Posts.OrderByDescending(x => x.DateAdded).Take(4).ToList();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

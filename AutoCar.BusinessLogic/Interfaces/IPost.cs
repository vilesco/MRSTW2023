using AutoCar.Domain.Entities.Post;
using AutoCar.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.BusinessLogic.Interfaces
{
    public interface IPost
    {
        ServiceResponse AddPostAction(PDbModel model);
        PDbModel GetById(int PostID);
        IEnumerable<PDbModel> GetAll();
        IEnumerable<PostMinimal> GetBySearchWrapData(PSearchWrapData searchWrapData);
        IEnumerable<PostMinimal> GetLatestPosts();
        void Update(PDbModel model);
        void Delete(int PostID);
        void Save();
    }
}

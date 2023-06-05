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
        PDbModel GetById(int postID);
        IEnumerable<PDbModel> GetAll();
        IEnumerable<PostMinimal> GetBySearchWrapData(PSearchWrapData searchWrapData);
        IEnumerable<PostMinimal> GetPostsByMakeOrLocation(string make);
        IEnumerable<PostMinimal> GetPostsByAuthor(string author);
        IEnumerable<PostMinimal> GetLatestPosts();
        IEnumerable<PostMinimal> GetPostsByListingFilter(PListingFilterData data);
        IEnumerable<PostMinimal> GetPostsByType(string type);
        void Update(PDbModel model);
        void Delete(int PostID);
        void Save();
    }
}

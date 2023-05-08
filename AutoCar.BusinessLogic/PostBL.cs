using AutoCar.BusinessLogic.Core;
using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Post;
using AutoCar.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.BusinessLogic
{
    public class PostBL : PostApi, IPost
    {
        public ServiceResponse AddPostAction(PDbModel model)
        {
            return AddPost(model);
        }
    }
}

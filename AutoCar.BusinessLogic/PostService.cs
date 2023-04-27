using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoCar.BusinessLogic.DBModel;
using AutoCar.Domain.Entities.Car;
using AutoCar.Domain.Entities.Response;

namespace AutoCar.BusinessLogic
{
    public class PostService
    {
        public ServiceResponse IncrementViewCount(ProductAPI post)
        {
            post.Views++;

            ProductContext.Entry(post).State = EntityState.Modified;
            ProductContext.SaveChanges();
            return Success();
        }

        public ServiceResponse Edit(ProductAPI post)
        {
            post.Story = post.Story.Trim();

            ProductContext.Entry(post).State = EntityState.Modified;
            ProductContext.SaveChanges();
            return Success();
        }

        public ServiceResponse Delete(ProductAPI post)
        {
            ProductContext.Entry(post).State = EntityState.Deleted;
            ProductContext.SaveChanges();
            return Success();
        }

        }
    }

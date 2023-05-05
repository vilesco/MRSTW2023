using AutoCar.Domain.Entities.Post;
using AutoCar.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.BusinessLogic.DBModel
{
    public class PostContext : DbContext
    {
            public PostContext() : base("name=AutoCar") { }
            public virtual DbSet<PDbModel> Posts { get; set; }
    }
}

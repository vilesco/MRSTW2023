using AutoCar.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=AutoCar") { }

        public virtual DbSet<UDbModel> Users { get; set; }
    }
}

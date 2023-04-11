using AutoCar.Domain.Entities.Session;
using AutoCar.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.BusinessLogic.DBModel
{
    public class SessionContext : DbContext
    {
        public SessionContext() : base("name=AutoCar") { }

        public virtual DbSet<SDbModel> Sessions { get; set; }
    }
}
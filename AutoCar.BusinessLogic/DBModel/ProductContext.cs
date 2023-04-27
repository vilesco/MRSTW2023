using AutoCar.Domain.Entities.Car;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.BusinessLogic.DBModel
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("name=Cars") { }

        public DbSet<ProductAPI> Posts { get; set; }
    }
}

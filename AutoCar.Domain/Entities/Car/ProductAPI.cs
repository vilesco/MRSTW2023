using AutoCar.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.Domain.Entities.Car
{
    public class ProductAPI
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Story { get; set; }
        public int Views { get; set; }
        public string Thumbnail { get; set; }
        public UserMinimal Author { get; set; }
        public DateTime Created { get; set; }
    }
}

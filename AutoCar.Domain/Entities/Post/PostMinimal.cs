using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.Domain.Entities.Post
{
    public class PostMinimal
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public int Millage { get; set; }
        public string Location { get; set; }
        public string Fuel { get; set; }
        public int EngineCapacity { get; set; }
        public string Transmission { get; set; }
        public int Price { get; set; }
        public DateTime DateAdded { get; set; }
        public string ImagePath { get; set; }
    }
}

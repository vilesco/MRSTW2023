using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCar.Web.Models
{
    public class PostListingData
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string Millage { get; set; }
        public string Location { get; set; }
        public string Fuel { get; set; }
        public int EngineCapacity { get; set; }
        public string Transmission { get; set;}
        public DateTime DateAdded { get; set; }
    }
}
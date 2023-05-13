using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoCar.Web.Models
{
    public class PostData
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }
        public int EngineCapacity { get; set; }
        public int Millage { get; set; }
        public string Fuel { get; set; }
        public bool ABS { get; set; }
        public bool AC { get; set; }
        public bool CruiseControl { get; set; }
        public bool KeylessEntry { get; set; }
        public bool AirBags { get; set; }
        public bool PowerWindows { get; set; }
        public int Price { get; set; }
        public string Location { get; set; }
        public string Comment { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateAdded { get; set; }
        public string Author { get; set; }
        public string AuthorPhoneNumber { get; set; }
    }
}
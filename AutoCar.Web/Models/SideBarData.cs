using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCar.Web.Models
{
    public class SideBarData
    {
        public string KeyWord { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public List<int> PriceRange { get; set; }
        public string Location { get; set; }
        public List<string> LocationList { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public List<int> YearRange { get; set; }
        public string Type { get; set; }
        public string Make { get; set; }
        public List<string> MakeList { get; set; }
        public string Transmission { get; set; }
        public string Fuel { get; set; }
    }
}
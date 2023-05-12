using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCar.Web.Models
{
    public class SearchWrapData
    {
        public string MakeOrModel { get; set; }
        public string PriceRange { get; set; }
        public string Location { get; set; }
    }
}
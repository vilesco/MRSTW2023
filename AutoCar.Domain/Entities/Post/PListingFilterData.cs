using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.Domain.Entities.Post
{
    public class PListingFilterData
    {
        public string KeyWord { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string Location { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public string Type { get; set; }
        public string Make { get; set; }
        public string Transmission { get; set; }
        public string Fuel { get; set; }
    }
}

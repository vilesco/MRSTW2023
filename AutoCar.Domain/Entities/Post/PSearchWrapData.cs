using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.Domain.Entities.Post
{
    public class PSearchWrapData
    {
        public string MakeOrModel { get; set; }
        public string PriceRange { get; set; }
        public string Location { get; set; }
    }
}

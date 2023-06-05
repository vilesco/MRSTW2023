using AutoCar.Domain.Entities.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCar.Web.Models
{
    public class ListingPageData
    {
        public List<PostMinimal> ListingItems { get; set; }
        public SideBarData SideBar { get; set; }
    }
}
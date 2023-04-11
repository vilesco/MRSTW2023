using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AutoCar.Domain.Entities.Response
{
     public class CookieResponse
     {
          public DateTime Data { get; set; } 
          public HttpCookie Cookie { get; set; }
     }
}

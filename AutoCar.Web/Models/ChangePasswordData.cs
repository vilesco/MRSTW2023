using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCar.Web.Models
{
     public class ChangePasswordData
     {
          public string NewPassword { get; set; }
          public string ConfirmedPassword { get; set;}
     }
}
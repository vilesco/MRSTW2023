﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.Domain.Entities.User
{
     public class UChangePasswordData
     {
          public string UserName { get; set; }    
          public string NewPassword { get; set; } 
          public string ConfirmedPassword { get; set; }
     }
}

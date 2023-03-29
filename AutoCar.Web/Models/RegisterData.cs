﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCar.Web.Models
{
    public class RegisterData
    {
        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Terms { get; set; }

    }
}
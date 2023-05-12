using AutoCar.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCar.Web.Models
{
    public class UserData
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public URole AccessLevel { get; set; }
    }
}
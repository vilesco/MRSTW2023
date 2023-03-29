using AutoCar.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.Domain.Entities.User
{
    public class URegisterData
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool Terms { get; set; }
        public string IP { get; set; }
        public DateTime RegisterDateTime { get; set; }
    }
}

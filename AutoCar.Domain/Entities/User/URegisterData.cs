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
        public string NewPassword { get; set; }
        public string UserName { get; set; }
        public string ConfirmedPassword { get; set; }
        public bool Terms { get; set; }
        public string IP { get; set; }
        public DateTime RegisterDateTime { get; set; }
    }
}

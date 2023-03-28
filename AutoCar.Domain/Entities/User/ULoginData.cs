using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.Domain.Entities.User
{
    public class ULoginData
    {
        public string IP { get; set; }
        public DateTime LastLoginTime { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }

}

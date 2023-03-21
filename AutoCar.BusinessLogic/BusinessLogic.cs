using AutoCar.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.BusinessLogic
{
    public class BusinessLogic
    {
          public ISession GetSessionBL()
          {
               return new SessionBL();
          }

    }
}

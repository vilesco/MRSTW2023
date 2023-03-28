using AutoCar.Domain.Entities.Response;
using AutoCar.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ServiceResponse ValidateUserCredential(ULoginData user);
        ServiceResponse ValidateNewPassword(UChangePasswordData password);
        ServiceResponse ValidateUserRegister(URegisterData newUser);
     }
}

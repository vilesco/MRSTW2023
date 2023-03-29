using AutoCar.BusinessLogic.Core;
using AutoCar.BusinessLogic.DBModel;
using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Response;
using AutoCar.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutoCar.BusinessLogic
{
    public class SessionBL : UserApi, ISession
    {
        public ServiceResponse ValidateUserCredential(ULoginData data)
        {
            return ReturnCredentialStatus(data);
        }
        public ServiceResponse ValidateNewPassword(UChangePasswordData password)
        {
            return ReturnPasswordStatus(password);
        }

        public ServiceResponse ValidateUserRegister(URegisterData newUser)
        {
            return ReturnRegisterStatus(newUser);
        }

    }
}

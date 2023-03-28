using AutoCar.BusinessLogic.DBModel;
using AutoCar.Domain.Entities.Response;
using AutoCar.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.BusinessLogic.Core
{
    public class UserApi
    {
        public ServiceResponse ReturnCredentialStatus(ULoginData user)
        {
            using(var db = new UserContext())
            {
                var userData = db.Users.FirstOrDefault(u=>u.UserName == user.UserName);

            }
            using(var db = new UserContext())
            {
                var newUser = new UDbModel()
                {
                    UserName = "costea",
                    Password = "12345655555",
                    Email = "costea@yandex.ru",
                    Terms = true,
                    FullName = "Costic",
                    AccessLevel = Domain.Enum.URole.USER,
                    RegisterDateTime = DateTime.Now,
                    LoginDateTime = DateTime.Now,
                   
                };
                db.Users.Add(newUser);
                db.SaveChanges();
            }

            return new ServiceResponse { Status = true, StatusMessage = string.Empty };
        }

        public ServiceResponse ReturnPasswordStatus(UChangePasswordData password)
        {
            return new ServiceResponse { Status = true, StatusMessage = "Password has been changed succesfully!" };
        }

        public ServiceResponse ReturnRegisterStatus(URegisterData newUser)
        {
            return new ServiceResponse { Status = true, StatusMessage = "New User profile was created successfully!" };
        }
    }
}

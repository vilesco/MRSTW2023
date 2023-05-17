using AutoCar.BusinessLogic.Core;
using AutoCar.BusinessLogic.DBModel;
using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Post;
using AutoCar.Domain.Entities.Response;
using AutoCar.Domain.Entities.User;
using AutoCar.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutoCar.BusinessLogic
{
    public class SessionBL : UserApi, ISession
    {
        private readonly UserContext _context;
        public SessionBL()
        {
            _context = new UserContext();
        }
        public SessionBL(UserContext context)
        {
            _context = context;
        }
        public IEnumerable<UDbModel> GetAll()
        {
            return _context.Users.ToList();
        }
        public ServiceResponse ValidateUserCredential(ULoginData data)
        {
            return ReturnCredentialStatus(data);
        }
        public ServiceResponse ChangePassword(UChangePasswordData password)
        {
            return ReturnChangedPassword(password);
        }

        public ServiceResponse ValidateUserRegister(URegisterData newUser)
        {
            return ReturnRegisterStatus(newUser);
        }
        public CookieResponse GenCookie(string username)
        {
            return CookieGeneratorAction(username);
        }

        public UserMinimal GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }

        public ServiceResponse EditProfileAction(UEditProfileData existingUser)
        {
            return ReturnEditedProfile(existingUser);
        }

        public UEditProfileData GetUserById (int userId)
        {
            return ReturnUserById(userId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoCar.Domain.Entities.Session;
using AutoCar.Domain.Entities.User;
using AutoCar.Domain.Enum;

namespace WebApplication1.Extensions
{
    public static class SessionExtensions
    {
        public static UDbModel GetUser(this HttpSessionStateBase session)
        {
            return (UDbModel)session["__User"];
        }

        public static void ClearUser(this HttpSessionStateBase session)
        {
            session.Remove("__User");
        }

        public static void SetUser(this HttpSessionStateBase session, UDbModel user)
		{
			session["__User"] = user;
		}

        public static bool IsUserLoggedIn(this HttpSessionStateBase session)
        {
            return session.GetUser() != null;
        }

        public static bool UserHasRole(this HttpSessionStateBase session, URole role)
        {
            if (!session.IsUserLoggedIn())
                return false;

            var user = session.GetUser();
            return user.AccessLevel >= role;
        }
    }
}
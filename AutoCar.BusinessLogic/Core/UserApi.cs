using AutoCar.BusinessLogic.DBModel;
using AutoCar.BusinessLogic.Interfaces;
using AutoCar.Domain.Entities.Response;
using AutoCar.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCar.BusinessLogic.Core
{
     public class UserApi
     {
          public ServiceResponse ReturnCredentialStatus(ULoginData user)
          {
               using (var db = new UserContext())
               {
                    var userData = db.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
                    if (userData == null)
                    {
                         return new ServiceResponse { Status = false, StatusMessage = "The Username or Password is Incorrect" };
                    }
               }

               return new ServiceResponse { Status = true, StatusMessage = string.Empty };
          }

          public ServiceResponse ReturnPasswordStatus(UChangePasswordData password)
          {
               return new ServiceResponse() { Status = true, StatusMessage= string.Empty };
           
          }

          public ServiceResponse ReturnRegisterStatus(URegisterData newUser)
          {
               var response = new ServiceResponse();
               using (var db = new UserContext())
               {
                    try
                    {
                         // Check if the user already exists in the database

                         var existingUser = db.Users.FirstOrDefault(u => u.Email == newUser.Email || u.UserName == newUser.UserName);
                         if (existingUser != null)
                         {
                              response.StatusMessage = "User with this email already exists";
                              response.Status = false;
                              return response;
                         }


                         // If the user does not exist, create a new user object and add it to the database
                         var user = new UDbModel
                         {
                              FullName = newUser.FullName,
                              UserName = newUser.UserName,
                              Email = newUser.Email,
                              Password = newUser.Password,
                              Terms = newUser.Terms,
                              RegisterDateTime = DateTime.Now,
                              LoginDateTime = DateTime.Now,
                              AccessLevel = Domain.Enum.URole.USER,

                         };
                         db.Users.Add(user);
                         db.SaveChanges();

                         response.StatusMessage = "User registered successfully";
                         response.Status = true;
                    }
                    catch (Exception ex)
                    {
                         response.StatusMessage = "An error occurred while registering the user";
                         response.Status = false;
                         //response.Exception = ex;
                    }
               }

               return response;
               //return new ServiceResponse { Status = true, StatusMessage = "New User profile was created successfully!" };
          }

          public ServiceResponse ReturnEditProfile(UEditProfileData user)
          {
               return new ServiceResponse { Status = true, StatusMessage = string.Empty };
          }


     }
}

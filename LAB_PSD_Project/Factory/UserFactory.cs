using LAB_PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_PSD_Project.Factory
{
    public class UserFactory
    {
        public static User CreateUser(int id, string name, string email, string gender, DateTime DOB, string password)
        {
            User user = new User();
            user.ID = id;
            user.Name = name;
            user.Email = email;
            user.Gender = gender;
            user.DOB = DOB;
            user.Password = password;
            user.Role = "customer";
           return user;
        }
    }
}
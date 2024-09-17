using LAB_PSD_Project.Model;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_PSD_Project.Repository
{
    public class UserRepository
    {
        private GMDatabaseEntities db = DatabaseSingleton.GetInstance();
        public List<User> GetUsers()
        {
            return (from u in db.Users select u).ToList();
        }

        public void addToDatabase(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void UpdateUserByID(int userID, string name, string email, string gender, DateTime DOB)
        {
            User user = db.Users.Find(userID);
            user.Email = email;
            user.Gender = gender;
            user.Name = name;
            user.DOB = DOB;
            db.SaveChanges();
        }

        public void UpdatePasswordByUserID(int userID, string newPass)
        {
            User user = db.Users.Find(userID);
            user.Password = newPass;
            db.SaveChanges();
        }
    }
}
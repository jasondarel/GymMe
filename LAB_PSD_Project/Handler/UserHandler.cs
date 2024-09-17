using LAB_PSD_Project.Factory;
using LAB_PSD_Project.Model;
using LAB_PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LAB_PSD_Project.Handler
{
    public class UserHandler
    {
        private UserRepository userRepo = new UserRepository();
        public User GetUserByNameAndPassword(string name, string password)
        {
            List<User> users = userRepo.GetUsers();
            foreach (User user in users)
            {
                if(user.Name.Equals(name) && user.Password.Equals(password))
                {
                    return user;
                }
            }
            return null;
        }

        private int GetLastID()
        {
            List<User> users = userRepo.GetUsers();
            if(users.Count != 0) return users.Last().ID;
            return 0;
        }

        public void addUser(string name, string email, string gender, DateTime DOB, string password)
        {
            User user = UserFactory.CreateUser(GetLastID()+1, name, email, gender, DOB, password);
            userRepo.addToDatabase(user);
        }

        public User GetUserByID(int id)
        {
            List<User> users = userRepo.GetUsers();
            foreach (User user in users)
            {
                if (user.ID == id) return user;
            }
            return null;
        }

        public List<User> GetCustomers()
        {
            List<User> users = userRepo.GetUsers();
            List<User> customers = new List<User>();
            foreach (User user in users)
            {
                if (user.Role.Equals("customer"))
                {
                    customers.Add(user);
                }
            }
            return customers;
        }

        public void UpdateUser(User user, string name, string email, string gender, DateTime DOB)
        {
            userRepo.UpdateUserByID(user.ID, name, email, gender, DOB);
        }

        public void UpdatePass(User user, string newPass)
        {
            userRepo.UpdatePasswordByUserID(user.ID, newPass);
        }
    }
}
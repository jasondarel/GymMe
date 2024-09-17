using LAB_PSD_Project.Handler;
using LAB_PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace LAB_PSD_Project.Controller
{
    public class UserController
    {
        private UserHandler userHandler = new UserHandler();
        public User Login(Label Error, string name, string password)
        {
            Error.Text = "";
            if(name.Length == 0 || password.Length == 0)
            {
                Error.Text += "> Please fill all the fields! </br>";
            }

            User user = userHandler.GetUserByNameAndPassword(name, password);
            if(user ==  null)
            {
                Error.Text += "> Invalid user credentials! </br>";
            }

            return user;
        }

        public bool Register(Label Error, string name, string email, string gender, string password, string confirmPassword, DateTime DOB)
        {
            Error.Text = "";
            if(email.Length == 0 || name.Length == 0 || email.Length == 0 || gender.Length == 0 || password.Length == 0 || confirmPassword.Length == 0 || DOB.Equals(DateTime.MinValue))
            {
                Error.Text += "> Please fill in all the fields! </br>";
            }

            if(name.Length <= 5 || name.Length >= 15)
            {
                Error.Text += "> Username must be between 5 and 15 characters! </br>";
            }

            Regex regex = new Regex(@"^[a-zA-Z\\s]+$");
            if(!regex.IsMatch(name))
            {
                Error.Text += "> Please input a valid username! (only alphabet and space) </br>";
            }

            if (!email.EndsWith(".com"))
            {
                Error.Text += "> Please input a valid email! (ends with .com) </br>";
            }

            if(!password.Equals(confirmPassword)) 
            {
                Error.Text += "> Password doesn't match Confirm Password! </br>";
            }

            regex = new Regex(@"^[a-zA-Z0-9]+$");
            if (!regex.IsMatch(password))
            {
                Error.Text += "> Please input a valid password! (only consists of alphanumeric) </br>";
            }

            if(Error.Text.Length == 0)
            {
                UserHandler userHandler = new UserHandler();

                userHandler.addUser(name, email, gender, DOB, password);

                return true;
            }
            return false;
        }

        public User GetUserByID(int id)
        {
            return userHandler.GetUserByID(id);
        }

        public void FillGV(GridView gv)
        {
            List<User> user = userHandler.GetCustomers();
            gv.DataSource = user;
            gv.DataBind();
        }

        public void UpdateProfile(Label errorLbl, User user, string name, string email, string gender, DateTime DOB)
        {
            errorLbl.Text = "";
            if(name.Length == 0 || email.Length == 0)
            {
                errorLbl.Text += "> Please fill in all the fields! </br>";
            }

            if (name.Length <= 5 || name.Length >= 15)
            {
                errorLbl.Text += "> Username must be between 5 and 15 characters! </br>";
            }

            Regex regex = new Regex(@"^[a-zA-Z\\s]+$");
            if (!regex.IsMatch(name))
            {
                errorLbl.Text += "> Please input a valid username! (only alphabet and space) </br>";
            }

            if (!email.EndsWith(".com"))
            {
                errorLbl.Text += "> Please input a valid email! (ends with .com) </br>";
            }

            if(errorLbl.Text.Length == 0) 
            {
                userHandler.UpdateUser(user, name, email, gender, DOB);
            }
        }

        public void UpdatePass(Label Error, User user, string oldPassword, string newPassword)
        {
            Error.Text = "";

            if(oldPassword.Length == 0 || newPassword.Length == 0)
            {
                Error.Text += "> Please fill in all the fields! </br>";
            }

            Regex regex = new Regex(@"^[a-zA-Z0-9]+$");
            if (!regex.IsMatch(newPassword))
            {
                Error.Text += "> Please input a valid password! (only consists of alphanumeric) </br>";
            }

            if(userHandler.GetUserByNameAndPassword(user.Name, oldPassword) == null)
            {
                Error.Text += "> Incorrect old password! </br>";
            }

            if(Error.Text.Length == 0)
            {
                userHandler.UpdatePass(user, newPassword);
            }
        }
    }
}
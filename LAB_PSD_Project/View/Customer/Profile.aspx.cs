using LAB_PSD_Project.Controller;
using LAB_PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB_PSD_Project.View.Customer
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null) return;
                User user = Session["user"] as User;

                Username.Value = user.Name;
                Email.Value = user.Email;
                if (user.Gender.Equals("Male"))
                {
                    Male.Checked = true;
                }
                else
                {
                    Female.Checked = true;
                }

                DOB.SelectedDate = user.DOB;
            }
        }

        protected void UpdateProfBtn_Click(object sender, EventArgs e)
        {
            UserController userController = new UserController();
            User user = Session["user"] as User;

            string username = Username.Value;
            string email = Email.Value;
            string gender = "";
            if (Male.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            DateTime dob = DOB.SelectedDate;

            userController.UpdateProfile(ErrorLbl1, user, username, email, gender, dob);
        }

        protected void UpdatePassBtn_Click(object sender, EventArgs e)
        {
            UserController userController = new UserController();
            User user = Session["user"] as User;

            string oldPass = OldPassword.Value;
            string newPass = NewPassword.Value;

            userController.UpdatePass(ErrorLbl2, user, oldPass, newPass);
        }
    }
}
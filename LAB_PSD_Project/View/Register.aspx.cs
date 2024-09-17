using LAB_PSD_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB_PSD_Project.View
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Login.aspx");
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string name = Name.Value;
            string email = Email.Value;
            string password = Password.Value;
            string confirmPassword = ConfirmPassword.Value;
            string gender = "";
            DateTime DOB = DOBCalendar.SelectedDate;

            if (Male.Checked)
            {
                gender = "Male";
            }
            else if (Female.Checked)
            {
                gender = "Female";
            }

            UserController userController = new UserController();

            if(userController.Register(ErrorLbl, name, email, gender, password, confirmPassword, DOB))
            {
                Response.Redirect("~/View/Login.aspx");
            }
        }
    }
}
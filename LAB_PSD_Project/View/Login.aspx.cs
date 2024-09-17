using LAB_PSD_Project.Controller;
using LAB_PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB_PSD_Project.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user-id"] != null)
            {
                if (Session["user"] == null)
                {
                    int userID = int.Parse(Request.Cookies["user-id"].Value);

                    UserController userController = new UserController();
                    Session["user"] = userController.GetUserByID(userID);
                }

                User user = Session["user"] as User;

                ToNextPage(user.Role);
            }
        }

        private void ToNextPage(string role)
        {
            if (role.Equals("admin"))
            {
                Response.Redirect("~/View/Admin/Home.aspx");
            }
            else
            {
                Response.Redirect("~/View/Customer/Home.aspx");
            }
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Register.aspx");
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string name = Name.Value;
            string password = Password.Value;
            UserController userController = new UserController();

            User user = userController.Login(ErrorLbl, name, password);

            if(user != null)
            {
                if (RememberMe.Checked)
                {
                    HttpCookie cookie = new HttpCookie("user-id");
                    cookie.Value = user.ID.ToString();
                    Response.Cookies.Add(cookie);
                }
                Session["user"] = user;

                ToNextPage(user.Role);
            }
        }
    }
}
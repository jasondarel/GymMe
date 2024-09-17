using LAB_PSD_Project.Controller;
using LAB_PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB_PSD_Project.View.Admin
{
    public partial class AdminNav : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user-id"] == null)
            {
                Response.Redirect("~/View/Login.aspx");
                return;
            }
            else if (Session["user"] == null)
            {
                UserController userController = new UserController();
                int userID = int.Parse(Request.Cookies["user-id"].Value);
                Session["user"] = userController.GetUserByID(userID);
            }

            User user = Session["user"] as User;
            if (!user.Role.Equals("admin"))
            {
                Response.Redirect("~/View/Login.aspx");
            }
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["user-id"] != null)
            {
                Response.Cookies["user-id"].Value = null;
                Response.Cookies["user-id"].Expires = DateTime.Now.AddDays(-1);
            }
            Session["user"] = null;
            Session.Remove("user");
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/View/Login.aspx");
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/Home.aspx");
        }

        protected void ProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/Profile.aspx");
        }

        protected void ManageSupplementBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/ManageSupplement.aspx");
        }

        protected void OrderQueueBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/TransactionQueue.aspx");
        }

        protected void TransactionReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/TransactionReportPage.aspx");
        }

        protected void HistoryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/History.aspx");
        }
    }
}
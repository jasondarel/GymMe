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
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) return;
            
            User user = Session["user"] as User;

            TransactionController transactionController = new TransactionController();
            transactionController.FillGV(TransactionHeaders, user);
        }

        protected void TransctionHeaders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Details"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = TransactionHeaders.Rows[rowIndex];

                int headerID = int.Parse(row.Cells[0].Text);

                Response.Redirect("~/View/TransactionDetailPage.aspx?id=" + headerID);
            }
        }
    }
}
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
    public partial class TransactionQueue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null) return;
                User user = Session["user"] as User;
                TransactionController controller = new TransactionController();
                controller.FillGV(Transactions, user);
            }
        }

        protected void Transactions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Handle"))
            {
                User user = Session["user"] as User;

                int rowIndex = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = Transactions.Rows[rowIndex];
                int transactionID = int.Parse(row.Cells[0].Text);

                TransactionController controller = new TransactionController();
                controller.HandleTransaction(Transactions, user, transactionID);
            }
        }
    }
}
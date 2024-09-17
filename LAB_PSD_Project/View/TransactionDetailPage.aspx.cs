using LAB_PSD_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB_PSD_Project.View
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            int transactionID;
            if (id == null || !int.TryParse(id, out transactionID))
            {
                Response.Redirect("~/View/Login.aspx");
                return;
            }

            TransactionController controller = new TransactionController();
            controller.ShowDetails(transactionID, IDLbl, UserLbl, DateLbl, StatusLbl, TransactionDetails);
        }
    }
}
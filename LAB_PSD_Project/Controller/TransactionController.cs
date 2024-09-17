using LAB_PSD_Project.Handler;
using LAB_PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LAB_PSD_Project.Controller
{
    public class TransactionController
    {
        private Handler.TransactionHandler transactionHandler = new Handler.TransactionHandler();
        public void FillGV(GridView gv, User user)
        {
            List<TransactionHeader> headers = transactionHandler.GetTransactionHeadersByUser(user);
            gv.DataSource = headers;
            gv.DataBind();
        }

        public List<TransactionHeader> GetTransactionHeaders(User user)
        {
            return transactionHandler.GetTransactionHeadersByUser(user);
        }

        public void ShowDetails(int transactionID, Label id, Label user, Label date, Label status, GridView gv)
        {
            TransactionHeader header = transactionHandler.GetTransactionHeader(transactionID);
            List<TransactionDetail> transactionDetails = transactionHandler.GetTransactionDetailsByHeader(header);

            id.Text = "ID: " + header.ID.ToString();
            user.Text = "User: " + header.User.Name;
            date.Text = "Date: " + header.TransactionDate.ToString();
            status.Text = "Status: " + header.Status;

            gv.DataSource = transactionDetails;
            gv.DataBind();
        }

        public void HandleTransaction(GridView gv, User user, int transactionID)
        {
            transactionHandler.HandleTransaction(transactionID);
            FillGV(gv, user);
        }
    }
}
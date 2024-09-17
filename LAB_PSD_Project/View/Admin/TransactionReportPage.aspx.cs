using LAB_PSD_Project.Controller;
using LAB_PSD_Project.Dataset;
using LAB_PSD_Project.Model;
using LAB_PSD_Project.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB_PSD_Project.View.Admin
{
    public partial class TransactionReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) return;
            User user = Session["user"] as User;

            TransactionReport report = new TransactionReport();
            TransactionReportViewer.ReportSource = report;

            TransactionController controller = new TransactionController();
            List<TransactionHeader> headers = controller.GetTransactionHeaders(user);

            TransactionDataset dataSet = new TransactionDataset();
            var reportHeader = dataSet.TransactionHeader;
            var reportDetail = dataSet.TransactionDetail;

            foreach (TransactionHeader header in headers)
            {
                var hrow = reportHeader.NewRow();
                hrow["ID"] = header.ID;
                hrow["UserID"] = header.UserID;
                hrow["User"] = header.User.Name;
                hrow["Transaction Date"] = header.TransactionDate;
                hrow["Status"] = header.Status;
                int grandTotal = 0;

                foreach (TransactionDetail detail in header.TransactionDetails)
                {
                    var drow = reportDetail.NewRow();
                    drow["TransactionID"] = detail.TransactionID;
                    drow["SupplementID"] = detail.SupplementID;
                    drow["Supplement"] = detail.Supplement.Name;
                    drow["Quantity"] = detail.Quantity;
                    int subtotal = detail.Quantity * detail.Supplement.Price;
                    drow["Subtotal"] = subtotal;
                    grandTotal += subtotal;
                    reportDetail.Rows.Add(drow);
                }

                hrow["Grand Total"] = grandTotal;
                reportHeader.Rows.Add(hrow);
            }

            report.SetDataSource(dataSet);
        }
    }
}
using LAB_PSD_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB_PSD_Project.View.Admin
{
    public partial class ManageSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshPage();
            }
        }

        private void RefreshPage()
        {
            SupplementController supplementController = new SupplementController();
            supplementController.FillGV(Supplements);
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/InsertSupplement.aspx");
        }

        protected void Supplements_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = Supplements.Rows[e.RowIndex];
            int supplementID = int.Parse(row.Cells[0].Text);
            SupplementController controller = new SupplementController();
            controller.RemoveSupplement(supplementID);
            RefreshPage();
        }

        protected void Supplements_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = Supplements.Rows[e.NewEditIndex];
            int supplementID = int.Parse(row.Cells[0].Text);
            Response.Redirect("~/View/Admin/UpdateSupplement.aspx?id=" + supplementID);
        }
    }
}
using LAB_PSD_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LAB_PSD_Project.View.Admin
{
    public partial class InsertSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SupplementController supplementController = new SupplementController();
                supplementController.FillDD(TypeNameDD);
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/ManageSupplement.aspx");
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            string name = NameTF.Value;
            string price = PriceTF.Value;
            string typeName = TypeNameDD.SelectedValue;
            DateTime expiryDate = ExpiredCal.SelectedDate;

            SupplementController supplementController = new SupplementController();
            if(supplementController.InsertSupplement(ErrorLbl, name, price, typeName, expiryDate))BackBtn_Click(sender, e);
        }
    }
}
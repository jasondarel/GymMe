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
    public partial class UpdateSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                int supplementID;
                if (id == null || !int.TryParse(id, out supplementID))
                {
                    Response.Redirect("~/View/Admin/ManageSupplement.aspx");
                    return;
                }

                SupplementController controller = new SupplementController();
                Supplement supplement = controller.GetSupplementByID(supplementID);

                controller.FillDD(TypeNameDD);

                NameTF.Value = supplement.Name;
                PriceTF.Value = supplement.Price.ToString();
                TypeNameDD.SelectedValue = supplement.SupplementType.Name;
                ExpiredCal.SelectedDate = supplement.ExpiryDate;
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/ManageSupplement.aspx");
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            string name = NameTF.Value;
            string price = PriceTF.Value;
            string type = TypeNameDD.SelectedValue;
            DateTime expiryDate = ExpiredCal.SelectedDate;

            SupplementController controller = new SupplementController();
            if (controller.UpdateSupplement(ErrorLbl, id, name, price, type, expiryDate))BackBtn_Click(sender, e);
        }
    }
}
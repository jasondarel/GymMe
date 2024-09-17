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
    public partial class OrderSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = Session["user"] as User;

                if (user == null) return;

                SupplementController supplementController = new SupplementController();
                CartController cartController = new CartController();

                supplementController.FillGV(Supplements);
                cartController.FillGV(Carts, user);
            }
        }

        protected void ClearCartBtn_Click(object sender, EventArgs e)
        {
            User user = Session["user"] as User;

            CartController cartController = new CartController();

            cartController.ClearCart(Carts, user);
        }

        protected void Supplements_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Order"))
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = Supplements.Rows[rowIndex];

                int supplementID = int.Parse(row.Cells[0].Text);
                TextBox quantityTextBox = row.FindControl("Quantity") as TextBox;
                string quantity = quantityTextBox.Text;
                quantityTextBox.Text = "";

                User user = Session["user"] as User;

                CartController cartController = new CartController();
                cartController.Order(Carts, user, supplementID, quantity);
            }
        }

        protected void ChekcoutBtn_Click(object sender, EventArgs e)
        {
            User user = Session["user"] as User;
            CartController cartController = new CartController();

            cartController.CheckOut(Carts, user);
        }
    }
}
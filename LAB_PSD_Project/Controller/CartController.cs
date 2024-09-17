using LAB_PSD_Project.Handler;
using LAB_PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LAB_PSD_Project.Controller
{
    public class CartController
    {
        private CartHandler cartHandler = new CartHandler();
        public void FillGV(GridView gridView, User user)
        {
            List<Cart> carts = cartHandler.GetCartsByUser(user);
            gridView.DataSource = carts;
            gridView.DataBind();
        }

        public void ClearCart(GridView gv, User user)
        {
            cartHandler.ClearCartByUser(user);
            FillGV(gv, user);
        }

        public void Order(GridView gv, User user, int supplementID, string quantityStr)
        {
            int quantity;
            if(quantityStr.Length == 0 || !int.TryParse(quantityStr, out quantity))
            {
                return;
            } 
            else if (quantity <= 0)
            {
                return;
            }

            cartHandler.CreateCartForUser(user, supplementID, quantity);
            FillGV(gv, user);
        }

        public void CheckOut(GridView gv, User user)
        {
            if(cartHandler.CartToTransaction(user)) ClearCart(gv, user);
        }
    }
}
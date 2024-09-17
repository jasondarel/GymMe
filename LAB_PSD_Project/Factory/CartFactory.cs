using LAB_PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_PSD_Project.Factory
{
    public class CartFactory
    {
        public static Cart CreateFactory(int id, int userID, int supplementID, int quantity)
        {
            Cart cart = new Cart();
            cart.ID = id;
            cart.UserID = userID;
            cart.SupplementID = supplementID;
            cart.Quantity = quantity;
            return cart;
        }
    }
}
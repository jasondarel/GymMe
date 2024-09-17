using LAB_PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_PSD_Project.Repository
{
    public class CartRepository
    {
        private GMDatabaseEntities db = DatabaseSingleton.GetInstance();
        public List<Cart> GetCartsByUserID(int userID)
        {
            return (from c in db.Carts where c.UserID == userID select c).ToList();
        }

        public void RemoveCart(Cart cart)
        {
            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public void AddCart(Cart cart) { 
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public void UpdateCartQuantityByID(int cartID, int quantity)
        {
            Cart cart = db.Carts.Find(cartID);
            cart.Quantity = quantity;
            db.SaveChanges();
        }

        public int GetLastID()
        {
            return (from c in db.Carts select c.ID).ToList().LastOrDefault();
        }
    }
}
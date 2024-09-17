using LAB_PSD_Project.Factory;
using LAB_PSD_Project.Model;
using LAB_PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_PSD_Project.Handler
{
    public class CartHandler
    {
        private CartRepository cartRepo = new CartRepository();
        public List<Cart> GetCartsByUser(User user)
        {
            return cartRepo.GetCartsByUserID(user.ID);
        }
        
        public void ClearCartByUser(User user)
        {
            List<Cart> carts = cartRepo.GetCartsByUserID(user.ID);

            foreach (Cart c in carts)
            {
                cartRepo.RemoveCart(c);
            }
        }

        public void CreateCartForUser(User user, int supplementID, int quantity)
        {
            List<Cart> carts = cartRepo.GetCartsByUserID(user.ID);
            Cart cart = null;
            foreach (Cart c in carts)
            {
                if(c.SupplementID == supplementID)
                {
                    cart = c;
                    break;
                }
            }

            if(cart != null)
            {
                quantity += cart.Quantity;
                cartRepo.UpdateCartQuantityByID(cart.ID, quantity);
                return;
            }

            cart = CartFactory.CreateFactory(cartRepo.GetLastID()+1, user.ID, supplementID, quantity);

            cartRepo.AddCart(cart);
        }

        public bool CartToTransaction(User user)
        {
            List<Cart> carts = cartRepo.GetCartsByUserID(user.ID);

            if(carts.Count > 0)
            {
                TransactionHandler transactionHandler = new TransactionHandler();
                TransactionHeader header = transactionHandler.CreateTransactionHeader(user);
                int headerID = header.ID;

                foreach (Cart c in carts)
                {
                    transactionHandler.CreateTransactionDetail(headerID, c);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
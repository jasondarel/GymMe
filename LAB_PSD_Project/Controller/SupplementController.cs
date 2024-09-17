using LAB_PSD_Project.Handler;
using LAB_PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace LAB_PSD_Project.Controller
{
    public class SupplementController
    {
        private SupplementHandler supplementHandler = new SupplementHandler();
        public void FillGV(GridView gridView)
        {
            List<Supplement> supplements = supplementHandler.GetSupplements();
            gridView.DataSource = supplements;
            gridView.DataBind();
        }

        public void FillDD(DropDownList dd)
        {
            dd.DataSource = supplementHandler.GetSupplementTypes();
            dd.DataBind();
        }

        public bool InsertSupplement(Label error, string name, string priceStr, string typeName, DateTime expired)
        {
            error.Text = "";
            if (name.Length == 0 || priceStr.Length == 0 || typeName.Length == 0 || expired.Equals(DateTime.MinValue) )
            {
                error.Text += "> Please fill in all the fields! </br>";
            }

            if (!name.Contains("Supplement"))
            {
                error.Text += "> Name must contain 'Supplement'! </br>";
            }

            int price;
            if(int.TryParse(priceStr, out price))
            {
                if (price < 3000)
                {
                    error.Text += "> Price must be at least 3000! </br>";
                }
            }
            else
            {
                error.Text += "> Please input a valid price! (only numbers) </br>";
            }

            if(expired.CompareTo(DateTime.Now) <= 0)
            {
                error.Text += "> Expiry Date must be greater than today's date! </br>";
            }

            if (error.Text.Length == 0)
            {
                supplementHandler.InsertSupplement(name, expired, price, typeName);
                return true;
            }
            return false;
        }

        public void RemoveSupplement(int id)
        {
            supplementHandler.RemoveSupplementByID(id);
        }

        public Supplement GetSupplementByID(int id)
        {
            return supplementHandler.GetSupplementByID(id);
        }

        public bool UpdateSupplement(Label error, int id, string name, string priceStr, string typeName, DateTime expired)
        {
            error.Text = "";
            if (name.Length == 0 || priceStr.Length == 0 || typeName.Length == 0 || expired.Equals(DateTime.MinValue))
            {
                error.Text += "> Please fill in all the fields! </br>";
            }

            if (!name.Contains("Supplement"))
            {
                error.Text += "> Name must contain 'Supplement'! </br>";
            }

            int price;
            if (int.TryParse(priceStr, out price))
            {
                if (price < 3000)
                {
                    error.Text += "> Price must be at least 3000! </br>";
                }
            }
            else
            {
                error.Text += "> Please input a valid price! (only numbers) </br>";
            }

            if (expired.CompareTo(DateTime.Now) <= 0)
            {
                error.Text += "> Expiry Date must be greater than today's date! </br>";
            }

            if (error.Text.Length == 0)
            {
                supplementHandler.UpdateSupplement(id, name, expired, price, typeName);
                return true;
            }
            return false;
        }
    }
}
using LAB_PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_PSD_Project.Factory
{
    public class SupplementFactory
    {
        public static Supplement CreateSupplement(int id, string name, DateTime expiryDate, int price, int typeID)
        {
            Supplement supplement = new Supplement();
            supplement.Id = id;
            supplement.Name = name;
            supplement.ExpiryDate = expiryDate;
            supplement.Price = price;
            supplement.TypeID = typeID;
            return supplement;
        }
    }
}
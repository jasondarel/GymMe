using LAB_PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_PSD_Project.Repository
{
    public class SupplementRepository
    {
        private GMDatabaseEntities db = DatabaseSingleton.GetInstance();
        public List<Supplement> GetSupplements()
        {
            return (from s in db.Supplements select s).ToList();
        }

        public void InsertSupplement(Supplement supplement)
        {
            db.Supplements.Add(supplement);
            db.SaveChanges();
        }

        public SupplementType GetSupplementTypeByName(string name) 
        {
            return (from t in db.SupplementTypes where t.Name.Equals(name) select t).ToList().FirstOrDefault();
        }

        public List<SupplementType> GetSupplementTypes()
        {
            return (from t in db.SupplementTypes select t).ToList();
        }

        public Supplement GetSupplementByID(int id)
        {
            return (from s in db.Supplements where s.Id == id select s).ToList().FirstOrDefault();
        }

        public void RemoveSupplement(Supplement supplement)
        {
            db.Supplements.Remove(supplement);
            db.SaveChanges();
        }

        public void UpdateSupplement(int id, Supplement supplement)
        {
            Supplement s = db.Supplements.Find(id);
            s.Name = supplement.Name;
            s.TypeID = supplement.TypeID;
            s.Price = supplement.Price;
            s.ExpiryDate = supplement.ExpiryDate;
            db.SaveChanges();
        }
    }
}
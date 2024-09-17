using LAB_PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_PSD_Project.Repository
{
    public class TransactionRepository
    {
        private GMDatabaseEntities db = DatabaseSingleton.GetInstance(); 
        public List<TransactionHeader> GetTransactionHeaders()
        {
            return (from t in db.TransactionHeaders select t).ToList();
        }

        public List<TransactionDetail> GetTransactionDetails()
        {
            return (from t in db.TransactionDetails select t).ToList();
        }

        public void AddTransactionHeader(TransactionHeader header)
        {
            db.TransactionHeaders.Add(header);
            db.SaveChanges();
        }

        public void AddTransactionDetail(TransactionDetail detail)
        {
            db.TransactionDetails.Add(detail);
            db.SaveChanges();
        }

        public void UpdateTransactionStatus(int id, string status)
        {
            TransactionHeader header = db.TransactionHeaders.Find(id);
            header.Status = status;
            db.SaveChanges();
        }
    }
}
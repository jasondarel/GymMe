using LAB_PSD_Project.Factory;
using LAB_PSD_Project.Model;
using LAB_PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_PSD_Project.Handler
{
    public class TransactionHandler
    {
        private TransactionRepository transactionRepo = new TransactionRepository();

        private int GetLastID()
        {
            List<TransactionHeader> headers = transactionRepo.GetTransactionHeaders();
            if(headers.Count > 0)
            {
                return headers.Last().ID;
            }
            return 0;
        }

        public TransactionHeader CreateTransactionHeader(User user)
        {
            TransactionHeader header = TransactionFactory.CreateTransactionHeader(GetLastID() + 1, user.ID, DateTime.Now, "unhandled");

            transactionRepo.AddTransactionHeader(header);

            return header;
        }

        public void CreateTransactionDetail(int transactionID, Cart cart)
        {
            TransactionDetail transactionDetail = TransactionFactory.CreateTransactionDetail(transactionID, cart.SupplementID, cart.Quantity);

            transactionRepo.AddTransactionDetail(transactionDetail);
        }

        public List<TransactionHeader> GetTransactionHeadersByUser(User user)
        {
            List<TransactionHeader> headers = transactionRepo.GetTransactionHeaders();
            if (user.Role.Equals("admin")) return headers;

            List<TransactionHeader> headersByUser = new List<TransactionHeader>();

            foreach(TransactionHeader header in headers)
            {
                if (header.UserID == user.ID) headersByUser.Add(header);
            }

            return headersByUser;
        }

        public TransactionHeader GetTransactionHeader(int transactionID)
        {
            List<TransactionHeader> headers = transactionRepo.GetTransactionHeaders();
            foreach(TransactionHeader header in headers)
            {
                if(header.ID == transactionID) return header;
            }
            return null;
        }

        public List<TransactionDetail> GetTransactionDetailsByHeader(TransactionHeader header)
        {
            List<TransactionDetail> details = transactionRepo.GetTransactionDetails();
            List<TransactionDetail> detailsByHeader = new List<TransactionDetail>();

            foreach(TransactionDetail detail in details)
            {
                if(header.ID == detail.TransactionID) detailsByHeader.Add(detail);
            }

            return detailsByHeader;
        }

        public void HandleTransaction(int transactionID)
        {
            transactionRepo.UpdateTransactionStatus(transactionID, "handled");
        }
    }
}
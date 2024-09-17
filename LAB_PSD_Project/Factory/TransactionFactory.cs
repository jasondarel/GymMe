using LAB_PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_PSD_Project.Factory
{
    public class TransactionFactory
    {
        public static TransactionHeader CreateTransactionHeader(int id, int userID, DateTime transactionDate, string status)
        {
            TransactionHeader transactionHeader = new TransactionHeader();
            transactionHeader.ID = id;
            transactionHeader.UserID = userID;
            transactionHeader.TransactionDate = transactionDate;
            transactionHeader.Status = status;
            return transactionHeader;
        }

        public static TransactionDetail CreateTransactionDetail(int transactionID, int supplementID, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail();
            transactionDetail.TransactionID = transactionID;
            transactionDetail.SupplementID = supplementID;
            transactionDetail.Quantity = quantity;
            return transactionDetail;
        }
    }
}
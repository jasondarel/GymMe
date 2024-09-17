using LAB_PSD_Project.Factory;
using LAB_PSD_Project.Model;
using LAB_PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace LAB_PSD_Project.Handler
{
    public class SupplementHandler
    {
        private SupplementRepository supplementRepo = new SupplementRepository();
        public List<Supplement> GetSupplements()
        {
            return supplementRepo.GetSupplements();
        } 

        public List<String> GetSupplementTypes()
        {
            List<SupplementType> types = supplementRepo.GetSupplementTypes();
            List<String> typeNames = new List<String>();
            foreach(SupplementType type in types)
            {
                typeNames.Add(type.Name);
            }
            return typeNames;
        }

        private int GetLastID()
        {
            List<Supplement> supplements = supplementRepo.GetSupplements();
            if(supplements.Count > 0 )
            {
                return supplements.Last().Id;
            }
            return 0;
        }

        public void InsertSupplement(string name, DateTime expired, int price, string typeName)
        {
            SupplementType type = supplementRepo.GetSupplementTypeByName(typeName);
            Supplement supplement = SupplementFactory.CreateSupplement(GetLastID()+1, name, expired, price, type.ID);
            supplementRepo.InsertSupplement(supplement);
        }

        public Supplement GetSupplementByID(int id)
        {
            return supplementRepo.GetSupplementByID(id);
        }

        public void RemoveSupplementByID(int supplementID)
        {
            Supplement supplement = GetSupplementByID(supplementID);
            supplementRepo.RemoveSupplement(supplement);
        }

        public void UpdateSupplement(int id, string name, DateTime expired, int price, string typeName)
        {
            SupplementType type = supplementRepo.GetSupplementTypeByName(typeName);
            Supplement supplement = SupplementFactory.CreateSupplement(GetLastID() + 1, name, expired, price, type.ID);
            supplementRepo.UpdateSupplement(id, supplement);
        }
    }
}
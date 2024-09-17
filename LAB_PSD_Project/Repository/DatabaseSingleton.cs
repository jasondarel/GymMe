using LAB_PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_PSD_Project.Repository
{
    public class DatabaseSingleton
    {
        private static GMDatabaseEntities db = null;
        public static GMDatabaseEntities GetInstance()
        {
            if(db == null)
            {
                db = new GMDatabaseEntities();
            }
            return db;
        }
    }
}
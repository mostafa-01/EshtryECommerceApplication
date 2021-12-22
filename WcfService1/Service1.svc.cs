using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Eshtry;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        EshtryDBContext EC = new EshtryDBContext();

       
        //Test purpose only
        public void InsertCategory()
        {
            /* EC.Categories.Add(new Category
             {
                 CategoryName = "clothsss"
             });
             EC.SaveChanges();*/
           /* var lastN = EC.Categories
                        .OrderByDescending(g => g.CategoryID)
                        .Take(2);
            EC.Categories.RemoveRange(lastN);
            EC.SaveChanges();*/
        }
    }
}

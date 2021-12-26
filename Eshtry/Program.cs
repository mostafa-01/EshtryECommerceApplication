using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshtry
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test code to create database first time
            /*using (var db = new EshtryDBContext())
            {
                db.Categories.Add(new Category
                {
                    CategoryName = "cloths"
                });
                db.SaveChanges();

            }*/
            //Test code to test serice
            /*ServiceReference1.Service1Client sv = new ServiceReference1.Service1Client();
            sv.InsertCategory();*/
        }
    }
}

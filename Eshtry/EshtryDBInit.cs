using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eshtry
{
    public class EshtryDBInit : DropCreateDatabaseIfModelChanges<EshtryDBContext>
    {
        protected override void Seed(EshtryDBContext context)
        {
            IList<Category> Categories = new List<Category>();

            Categories.Add(new Category() { CategoryID =  1 , CategoryName = "Fashion"});
            Categories.Add(new Category() { CategoryID =  2 , CategoryName = "SuperMarket"});
            Categories.Add(new Category() { CategoryID =  3 , CategoryName = "Electronics"});
            Categories.Add(new Category() { CategoryID =  4 , CategoryName = "Gaming"});
            Categories.Add(new Category() { CategoryID =  5 , CategoryName = "Sport"});

            context.Categories.AddRange(Categories);

            base.Seed(context);
        }
    }
}
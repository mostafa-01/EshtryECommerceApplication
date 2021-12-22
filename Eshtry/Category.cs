using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshtry
{
    public class Category
    {
       
        public int CategoryID {get; set;}


        public String CategoryName { get; set; }

        public virtual IList<Item> Items { get; set; }



    }
}
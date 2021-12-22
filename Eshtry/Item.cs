using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshtry
{
    public class Item
    {
       
        public int ItemID { get; set; }
        public string ItemImage { get; set; }
        public string ItemTittle { get; set; }
        public string ItemDescription { get; set; }
        public float Price { get; set; }
        public int ItemQuantity { get; set; }
        public string Seller { get; set; }
        public virtual Category Category { get; set; }

    }
}
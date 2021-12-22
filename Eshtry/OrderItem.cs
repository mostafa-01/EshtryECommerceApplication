using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eshtry
{
    public class OrderItem
    {


        [Key, Column(Order = 0)]
        //[System.ComponentModel.DataAnnotations.Schema.ForeignKey("Order")]
        public int OrderID {get; set;}

        [Key, Column(Order = 1)]
        //[System.ComponentModel.DataAnnotations.Schema.ForeignKey("Item")]
        public int ItemID { get; set;}

        public int Quantity { get; set; }
        public virtual Item Item { get; set;}
        public virtual Order Order{ get; set;}



    }
}
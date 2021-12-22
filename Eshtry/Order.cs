using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshtry
{
    public class Order
    {
        
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }

        /*
         * 
         * States and its values
         * 1 ==> InCArt
         * 0 ==> Deleviring
         * -1 ==> Delevired
         * The state of the order will be (1) By default it means (InCart) By default
         * */
        public int state { get; set; } = 1;
        public float TotalPrice { get; set; } = 0;

        public virtual User User { get; set; }


    }
}
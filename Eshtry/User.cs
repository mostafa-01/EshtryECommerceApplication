using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eshtry
{
    public class User
    {
        
        public int UserID { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string UserName{ get; set; }
        public string Address{ get; set; }
        public string PhoneNumber { get; set; }
        public  string Email { get; set; }

        public virtual IList<Order> Orders { get; set; }

    }
}
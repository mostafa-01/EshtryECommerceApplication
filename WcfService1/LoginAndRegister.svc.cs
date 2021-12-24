using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Eshtry;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service2.svc or Service2.svc.cs at the Solution Explorer and start debugging.
    public class Service2 : LoginAndRegister
    {
        public void DoWork()
        {
        }
        EshtryDBContext Eshtrydb = new EshtryDBContext();

        public bool Register(string username, string password, int age, string gender, string address, string phonenumber
            , string email)
        {
            try
            {
                User User = new User();

                User.UserName = username;
                User.Password = password;
                User.Age = age;
                User.Gender = gender;
                User.Address = address;
                User.PhoneNumber = phonenumber;
                User.Email = email;

                Eshtrydb.Users.Add(User);

                Order Order = new Order();

                Order.state = 1;
                Order.TotalPrice = 0;
                Order.User = User;

                Eshtrydb.Orders.Add(Order);

                Eshtrydb.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public int Login(string email, string password)
        {
            /*
                This Methode returns:
                User ID if the user who wants to login is registered
                0 if the user who wants to login is Admin
               -1 if the user who wants to login is not registered or an exception is thrown
            */
            try
            {
                var User = Eshtrydb.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
                if (email.ToLower() == "admin@eshtry.com" && password.ToLower() == "admin")
                {
                    return 0;
                }
                else if (User == null)
                {
                    return -1;
                }
                else
                    return User.UserID;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return -1;
            }
        }
    }
}

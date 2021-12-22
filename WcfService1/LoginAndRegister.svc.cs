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

        //Not Tested Yet
        public bool Register(string username, string passwoard, int age, string gender, string address, string phonenumber
            , string email)
        {
            try
            {
                User User = new User();
                if(Eshtrydb.Users.ToList().Count == 0)
                {
                    User.UserID = 1;
                }
                else
                {
                    User.UserID = Eshtrydb.Users.ToList().Max(x => x.UserID) + 1;
                }

                User.UserName = username;
                User.Password = passwoard;
                User.Age = age;
                User.Gender = gender;
                User.Address = address;
                User.PhoneNumber = phonenumber;
                User.Email = email;

                Eshtrydb.Users.Add(User);
                Eshtrydb.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        //Not Tested Yet
        public int Login(string email, string passwoard)
        {
            /*
                This Methode returns:
                1 if the user who wants to login is registered
                0 if the user who wants to login is Admin
               -1 if the user who wants to login is not registered or an exception is thrown
            */
            try
            {
                var User = Eshtrydb.Users.FirstOrDefault(x => x.Email == email && x.Password == passwoard);
                if (email.ToLower() == "admin@eshtry.com" && passwoard.ToLower() == "admin")
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

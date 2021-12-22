using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Eshtry;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2" in both code and config file together.
    [ServiceContract]
    public interface LoginAndRegister
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        bool Register(string username , string passwoard , int age , string gender , string address 
            , string phonenumber ,string email );

        [OperationContract]
        int Login(string email , string passwoard);


    }
}

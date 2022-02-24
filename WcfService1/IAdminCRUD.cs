using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Eshtry;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminCRUD" in both code and config file together.
    [ServiceContract]
    public interface IAdminCRUD
    {
        [OperationContract]
        void DoWork();

        [OperationContract]

        bool AddCategory(string CatTittle);

        [OperationContract]
        bool AddItem(string tittle , string description , string image , int quantity 
            , float price , string seller , string CategoryName);

        [OperationContract]
        string[] getItem(int itemid);


        [OperationContract]
        string EditItem(int id , string tittle, string description, string image, int quantity
            , float price, string seller, string CategoryName);

        [OperationContract]
        bool DeleteItem(int itemid);
        [OperationContract]
        bool SetDelivered(int orderid);
    }
}

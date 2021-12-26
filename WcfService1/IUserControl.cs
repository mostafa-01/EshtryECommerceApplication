using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserControl" in both code and config file together.
    [ServiceContract]
    public interface IUserControl
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        string[][] ListItems();

        [OperationContract]
        void AddToCart(int ItemID , int UserID , int Quantity);
        
        [OperationContract]
        void Removefromcart(int ItemID, int UserID);
        
        [OperationContract]
        void Clearcart(int UserID);

        [OperationContract]
        string[][] Viewcart(int UserID);

        [OperationContract]
        string[][] getDeleviredOrders(int userid);

        [OperationContract]
        string[][] getDeleviringOrders(int userid);
        [OperationContract]
        float Checkout(int userid);
        [OperationContract]
        int OrderItemsQuantity(int orderID);

        [OperationContract]
        List<string> getUserInfo(int userid);
        
        //[OperationContract]
        //bool editPassword(int userid);
        
        [OperationContract]
        bool editUserInfo(int userid, string name , string gender , string phone , string address);
    }
}

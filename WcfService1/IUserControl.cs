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
        List<string> ListItems();

        [OperationContract]
        void AddToCart(int ItemID , int UserID , int Quantity);
        
        [OperationContract]
        void Removefromcart(int ItemID, int UserID, int Quantity);
        
        [OperationContract]
        void Clearcart(int UserID);

        [OperationContract]
        List<string> Viewcart(int UserID);

        [OperationContract]
        List<string> getDeleviredOrders(int userid);

        [OperationContract]
        List<string> getDeleviringOrders(int userid);
    }
}

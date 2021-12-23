using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISearch" in both code and config file together.
    [ServiceContract]
    public interface ISearch
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        List<string> Recomendations(string PartOfItemName);

        [OperationContract]
        List<string> SearchByItemName(string ItemName);

        [OperationContract]
        List<string> FilterItemsInCategory(int CategoryID);

        [OperationContract]
        List<string> getCategories();

    }
}

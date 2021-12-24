﻿using System;
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
        string[][] SearchByItemName(string ItemName, string CategoryName);

        [OperationContract]
        string[][] FilterItemsInCategory(string CategoryName);

        [OperationContract]
        List<string> getCategories();

    }
}

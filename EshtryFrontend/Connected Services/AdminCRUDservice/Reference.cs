﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EshtryFrontend.AdminCRUDservice {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AdminCRUDservice.IAdminCRUD")]
    public interface IAdminCRUD {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdminCRUD/DoWork", ReplyAction="http://tempuri.org/IAdminCRUD/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdminCRUD/DoWork", ReplyAction="http://tempuri.org/IAdminCRUD/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdminCRUD/AddCategory", ReplyAction="http://tempuri.org/IAdminCRUD/AddCategoryResponse")]
        bool AddCategory(string CatTittle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdminCRUD/AddCategory", ReplyAction="http://tempuri.org/IAdminCRUD/AddCategoryResponse")]
        System.Threading.Tasks.Task<bool> AddCategoryAsync(string CatTittle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdminCRUD/AddItem", ReplyAction="http://tempuri.org/IAdminCRUD/AddItemResponse")]
        bool AddItem(string tittle, string description, string image, int quantity, float price, string seller, string CategoryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdminCRUD/AddItem", ReplyAction="http://tempuri.org/IAdminCRUD/AddItemResponse")]
        System.Threading.Tasks.Task<bool> AddItemAsync(string tittle, string description, string image, int quantity, float price, string seller, string CategoryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdminCRUD/getItem", ReplyAction="http://tempuri.org/IAdminCRUD/getItemResponse")]
        string[] getItem(int itemid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdminCRUD/getItem", ReplyAction="http://tempuri.org/IAdminCRUD/getItemResponse")]
        System.Threading.Tasks.Task<string[]> getItemAsync(int itemid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdminCRUD/EditItem", ReplyAction="http://tempuri.org/IAdminCRUD/EditItemResponse")]
        string EditItem(int id, string tittle, string description, string image, int quantity, float price, string seller, string CategoryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdminCRUD/EditItem", ReplyAction="http://tempuri.org/IAdminCRUD/EditItemResponse")]
        System.Threading.Tasks.Task<string> EditItemAsync(int id, string tittle, string description, string image, int quantity, float price, string seller, string CategoryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdminCRUD/DeleteItem", ReplyAction="http://tempuri.org/IAdminCRUD/DeleteItemResponse")]
        bool DeleteItem(int itemid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdminCRUD/DeleteItem", ReplyAction="http://tempuri.org/IAdminCRUD/DeleteItemResponse")]
        System.Threading.Tasks.Task<bool> DeleteItemAsync(int itemid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdminCRUD/SetDelivered", ReplyAction="http://tempuri.org/IAdminCRUD/SetDeliveredResponse")]
        bool SetDelivered(int orderid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdminCRUD/SetDelivered", ReplyAction="http://tempuri.org/IAdminCRUD/SetDeliveredResponse")]
        System.Threading.Tasks.Task<bool> SetDeliveredAsync(int orderid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAdminCRUDChannel : EshtryFrontend.AdminCRUDservice.IAdminCRUD, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AdminCRUDClient : System.ServiceModel.ClientBase<EshtryFrontend.AdminCRUDservice.IAdminCRUD>, EshtryFrontend.AdminCRUDservice.IAdminCRUD {
        
        public AdminCRUDClient() {
        }
        
        public AdminCRUDClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AdminCRUDClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AdminCRUDClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AdminCRUDClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public bool AddCategory(string CatTittle) {
            return base.Channel.AddCategory(CatTittle);
        }
        
        public System.Threading.Tasks.Task<bool> AddCategoryAsync(string CatTittle) {
            return base.Channel.AddCategoryAsync(CatTittle);
        }
        
        public bool AddItem(string tittle, string description, string image, int quantity, float price, string seller, string CategoryName) {
            return base.Channel.AddItem(tittle, description, image, quantity, price, seller, CategoryName);
        }
        
        public System.Threading.Tasks.Task<bool> AddItemAsync(string tittle, string description, string image, int quantity, float price, string seller, string CategoryName) {
            return base.Channel.AddItemAsync(tittle, description, image, quantity, price, seller, CategoryName);
        }
        
        public string[] getItem(int itemid) {
            return base.Channel.getItem(itemid);
        }
        
        public System.Threading.Tasks.Task<string[]> getItemAsync(int itemid) {
            return base.Channel.getItemAsync(itemid);
        }
        
        public string EditItem(int id, string tittle, string description, string image, int quantity, float price, string seller, string CategoryName) {
            return base.Channel.EditItem(id, tittle, description, image, quantity, price, seller, CategoryName);
        }
        
        public System.Threading.Tasks.Task<string> EditItemAsync(int id, string tittle, string description, string image, int quantity, float price, string seller, string CategoryName) {
            return base.Channel.EditItemAsync(id, tittle, description, image, quantity, price, seller, CategoryName);
        }
        
        public bool DeleteItem(int itemid) {
            return base.Channel.DeleteItem(itemid);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteItemAsync(int itemid) {
            return base.Channel.DeleteItemAsync(itemid);
        }
        
        public bool SetDelivered(int orderid) {
            return base.Channel.SetDelivered(orderid);
        }
        
        public System.Threading.Tasks.Task<bool> SetDeliveredAsync(int orderid) {
            return base.Channel.SetDeliveredAsync(orderid);
        }
    }
}

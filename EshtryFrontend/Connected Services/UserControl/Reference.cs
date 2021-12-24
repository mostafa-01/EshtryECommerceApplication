﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EshtryFrontend.UserControl {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserControl.IUserControl")]
    public interface IUserControl {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/DoWork", ReplyAction="http://tempuri.org/IUserControl/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/DoWork", ReplyAction="http://tempuri.org/IUserControl/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/ListItems", ReplyAction="http://tempuri.org/IUserControl/ListItemsResponse")]
        string[][] ListItems();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/ListItems", ReplyAction="http://tempuri.org/IUserControl/ListItemsResponse")]
        System.Threading.Tasks.Task<string[][]> ListItemsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/AddToCart", ReplyAction="http://tempuri.org/IUserControl/AddToCartResponse")]
        void AddToCart(int ItemID, int UserID, int Quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/AddToCart", ReplyAction="http://tempuri.org/IUserControl/AddToCartResponse")]
        System.Threading.Tasks.Task AddToCartAsync(int ItemID, int UserID, int Quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/Removefromcart", ReplyAction="http://tempuri.org/IUserControl/RemovefromcartResponse")]
        void Removefromcart(int ItemID, int UserID, int Quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/Removefromcart", ReplyAction="http://tempuri.org/IUserControl/RemovefromcartResponse")]
        System.Threading.Tasks.Task RemovefromcartAsync(int ItemID, int UserID, int Quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/Clearcart", ReplyAction="http://tempuri.org/IUserControl/ClearcartResponse")]
        void Clearcart(int UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/Clearcart", ReplyAction="http://tempuri.org/IUserControl/ClearcartResponse")]
        System.Threading.Tasks.Task ClearcartAsync(int UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/Viewcart", ReplyAction="http://tempuri.org/IUserControl/ViewcartResponse")]
        string[][] Viewcart(int UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/Viewcart", ReplyAction="http://tempuri.org/IUserControl/ViewcartResponse")]
        System.Threading.Tasks.Task<string[][]> ViewcartAsync(int UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/getDeleviredOrders", ReplyAction="http://tempuri.org/IUserControl/getDeleviredOrdersResponse")]
        string[][] getDeleviredOrders(int userid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/getDeleviredOrders", ReplyAction="http://tempuri.org/IUserControl/getDeleviredOrdersResponse")]
        System.Threading.Tasks.Task<string[][]> getDeleviredOrdersAsync(int userid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/getDeleviringOrders", ReplyAction="http://tempuri.org/IUserControl/getDeleviringOrdersResponse")]
        string[][] getDeleviringOrders(int userid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/getDeleviringOrders", ReplyAction="http://tempuri.org/IUserControl/getDeleviringOrdersResponse")]
        System.Threading.Tasks.Task<string[][]> getDeleviringOrdersAsync(int userid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/Checkout", ReplyAction="http://tempuri.org/IUserControl/CheckoutResponse")]
        float Checkout(int userid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserControl/Checkout", ReplyAction="http://tempuri.org/IUserControl/CheckoutResponse")]
        System.Threading.Tasks.Task<float> CheckoutAsync(int userid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserControlChannel : EshtryFrontend.UserControl.IUserControl, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserControlClient : System.ServiceModel.ClientBase<EshtryFrontend.UserControl.IUserControl>, EshtryFrontend.UserControl.IUserControl {
        
        public UserControlClient() {
        }
        
        public UserControlClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserControlClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserControlClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserControlClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public string[][] ListItems() {
            return base.Channel.ListItems();
        }
        
        public System.Threading.Tasks.Task<string[][]> ListItemsAsync() {
            return base.Channel.ListItemsAsync();
        }
        
        public void AddToCart(int ItemID, int UserID, int Quantity) {
            base.Channel.AddToCart(ItemID, UserID, Quantity);
        }
        
        public System.Threading.Tasks.Task AddToCartAsync(int ItemID, int UserID, int Quantity) {
            return base.Channel.AddToCartAsync(ItemID, UserID, Quantity);
        }
        
        public void Removefromcart(int ItemID, int UserID, int Quantity) {
            base.Channel.Removefromcart(ItemID, UserID, Quantity);
        }
        
        public System.Threading.Tasks.Task RemovefromcartAsync(int ItemID, int UserID, int Quantity) {
            return base.Channel.RemovefromcartAsync(ItemID, UserID, Quantity);
        }
        
        public void Clearcart(int UserID) {
            base.Channel.Clearcart(UserID);
        }
        
        public System.Threading.Tasks.Task ClearcartAsync(int UserID) {
            return base.Channel.ClearcartAsync(UserID);
        }
        
        public string[][] Viewcart(int UserID) {
            return base.Channel.Viewcart(UserID);
        }
        
        public System.Threading.Tasks.Task<string[][]> ViewcartAsync(int UserID) {
            return base.Channel.ViewcartAsync(UserID);
        }
        
        public string[][] getDeleviredOrders(int userid) {
            return base.Channel.getDeleviredOrders(userid);
        }
        
        public System.Threading.Tasks.Task<string[][]> getDeleviredOrdersAsync(int userid) {
            return base.Channel.getDeleviredOrdersAsync(userid);
        }
        
        public string[][] getDeleviringOrders(int userid) {
            return base.Channel.getDeleviringOrders(userid);
        }
        
        public System.Threading.Tasks.Task<string[][]> getDeleviringOrdersAsync(int userid) {
            return base.Channel.getDeleviringOrdersAsync(userid);
        }
        
        public float Checkout(int userid) {
            return base.Channel.Checkout(userid);
        }
        
        public System.Threading.Tasks.Task<float> CheckoutAsync(int userid) {
            return base.Channel.CheckoutAsync(userid);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Eshtry;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserControl" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserControl.svc or UserControl.svc.cs at the Solution Explorer and start debugging.
    public class UserControl : IUserControl
    {

        EshtryDBContext Eshtrydb = new EshtryDBContext();
        public void DoWork()
        {
        }

        public void AddToCart(int ItemID, int UserID, int Quantity)
        {
            Order order = Eshtrydb.Orders.FirstOrDefault(x => x.User.UserID == UserID && x.state == 1);

            Item item = Eshtrydb.Items.FirstOrDefault(x => x.ItemID == ItemID);

            OrderItem orderItem = Eshtrydb.OrderItems.FirstOrDefault(x => x.ItemID == ItemID && x.OrderID == order.OrderID);

            if(orderItem == null)
            {
                //Expecting error null refrence for orderitem.item and orderitem.order
                orderItem = new OrderItem();
                orderItem.OrderID = order.OrderID;
                orderItem.ItemID = ItemID;
                orderItem.Quantity= Quantity;
                order.TotalPrice += item.Price * Quantity;

                Eshtrydb.OrderItems.Add(orderItem);
                //Eshtrydb.SaveChanges();
            }
            else
            {
                if (orderItem.Quantity + Quantity <= item.ItemQuantity)
                {
                    orderItem.Quantity += Quantity;
                    order.TotalPrice += item.Price * Quantity;

                }
                else
                {
                    order.TotalPrice += (item.ItemQuantity - orderItem.Quantity ) * item.Price ;
                    orderItem.Quantity = item.ItemQuantity;

                    //order.TotalPrice -= (Item.Quantity - Item.Item.ItemQuantity) * Item.Item.Price;

                }

                //Eshtrydb.SaveChanges();
            }


            Eshtrydb.SaveChanges();
        }

        public List<List<string>> ListItems()
        {
            try
            {
                List<Item> items = Eshtrydb.Items.ToList();

                var ItemsList = new List<List<string>>();

                var itemlist = new List<string>();

                foreach (var item in items)
                {
                    if (item.ItemQuantity != 0)
                    {
                        itemlist.Add(item.ItemID.ToString());
                        itemlist.Add(item.ItemImage);
                        itemlist.Add(item.ItemTittle);
                        itemlist.Add(item.ItemDescription);
                        itemlist.Add(item.Price.ToString());
                        itemlist.Add(item.ItemQuantity.ToString());
                        itemlist.Add(item.Seller);
                        itemlist.Add(item.Category.CategoryName);

                        ItemsList.Add(itemlist);
                        itemlist = new List<string>();
                    }
                }

                return ItemsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public void Removefromcart(int ItemID, int UserID)
        {
            Order order = Eshtrydb.Orders.FirstOrDefault(x => x.User.UserID == UserID && x.state == 1);

            Item item = Eshtrydb.Items.FirstOrDefault(x => x.ItemID == ItemID);

            OrderItem orderItem = Eshtrydb.OrderItems.FirstOrDefault(x => x.ItemID == ItemID && x.OrderID == order.OrderID);
            order.TotalPrice -= item.Price * orderItem.Quantity;
            Eshtrydb.OrderItems.Remove(orderItem);
            Eshtrydb.SaveChanges();
        }

        public void Clearcart(int UserID)
        {
            Order order = Eshtrydb.Orders.FirstOrDefault(x => x.User.UserID == UserID && x.state == 1);
            var orderitems = Eshtrydb.OrderItems.ToList();

            foreach(var orderitem in orderitems)
            {
                Eshtrydb.OrderItems.Remove(orderitem);
            }

            order.TotalPrice = 0;
            Eshtrydb.SaveChanges();
        }

        public List<List<string>> Viewcart(int UserID)
        {
            //Last array index is the total price

            Order order = Eshtrydb.Orders.FirstOrDefault(x => x.User.UserID == UserID && x.state == 1);

            var orderItems = Eshtrydb.OrderItems.Where(x => x.OrderID == order.OrderID).ToList();

            var OrderItemsList = new List<List<string>>();

            var orderitemlist = new List<string>();

            foreach(var orderitem in orderItems)
            {
                if (orderitem.Item.ItemQuantity < orderitem.Quantity)
                {
                    order.TotalPrice -= (orderitem.Quantity - orderitem.Item.ItemQuantity) * orderitem.Item.Price;
                    orderitem.Quantity = orderitem.Item.ItemQuantity;
                    Eshtrydb.SaveChanges();
                }
               
                    orderitemlist.Add(orderitem.Item.ItemID.ToString());
                    orderitemlist.Add(orderitem.Item.ItemTittle);
                    orderitemlist.Add(orderitem.Quantity.ToString());
                    orderitemlist.Add(orderitem.Item.Price.ToString());
                    orderitemlist.Add(orderitem.Item.ItemImage);
                    orderitemlist.Add(orderitem.Item.ItemQuantity.ToString());


                    OrderItemsList.Add(orderitemlist);
                    orderitemlist = new List<string>();
                
            }
            orderitemlist.Add(order.TotalPrice.ToString());
            OrderItemsList.Add(orderitemlist);

            return OrderItemsList;

        }

        public List<List<string>> getOrdersHistory(int userid , int state)
        {
            var orders = Eshtrydb.Orders.Where(x => x.User.UserID == userid && x.state == state).ToList();

            var OrderList = new List<List<string>>();

            var itemlist = new List<string>();

            foreach (var order in orders)
            {
                itemlist.Add(".");
                OrderList.Add(itemlist);
                itemlist = new List<string>();

                itemlist.Add(order.OrderID.ToString());
                itemlist.Add(order.OrderDate.ToString());
                itemlist.Add(order.TotalPrice.ToString());
                OrderList.Add(itemlist);
                itemlist = new List<string>();

                var orderItems = Eshtrydb.OrderItems.Where(x => x.OrderID == order.OrderID).ToList();
                foreach (var Item in orderItems)
                {
                    itemlist.Add(Item.Item.ItemTittle);
                    itemlist.Add(Item.Quantity.ToString());
                    itemlist.Add(Item.Item.Price.ToString());
                    itemlist.Add(Item.Item.ItemImage);
                    OrderList.Add(itemlist);
                    itemlist = new List<string>();
                }
            }
                itemlist.Add(".");
                OrderList.Add(itemlist);

            return OrderList;
        }

       
        public float Checkout(int userid)
        {
            Order order = Eshtrydb.Orders.FirstOrDefault(x => x.User.UserID == userid && x.state == 1);
            order.OrderDate = DateTime.Now;
            order.state = 0;
            var orderItems = Eshtrydb.OrderItems.Where(x => x.OrderID == order.OrderID).ToList();
            if (orderItems.Count == 0)
                return 0;
            foreach (var Item in orderItems)
            {
                Item.Item.ItemQuantity -= Item.Quantity;
            }

            Order Cart = new Order();
            Cart.state = 1;
            Cart.TotalPrice = 0;
            Cart.User = order.User;
            
            Eshtrydb.Orders.Add(Cart);
            Eshtrydb.SaveChanges();
            return order.TotalPrice;
        }

        public int OrderItemsQuantity(int orderID)
        {
            int quantity=0;
            var orderitems = Eshtrydb.OrderItems.Where(x => x.OrderID == orderID).ToList();
            foreach (var Item in orderitems)
            {
                quantity += Item.Quantity;
            }
                return quantity;
        

        }

        public List<string> getUserInfo(int userid)
        {
            var user = Eshtrydb.Users.FirstOrDefault(x => x.UserID == userid);

            List<string> UserInfo = new List<string>();

            string s = null;

            s = user.UserName;
            UserInfo.Add(s);

            s = user.Email;
            UserInfo.Add(s);

            s = user.Gender;
            UserInfo.Add(s);
            
            s = user.PhoneNumber;
            UserInfo.Add(s);
            
            s = user.Address;
            UserInfo.Add(s);

            return UserInfo;
        }

        public bool editUserInfo(int userid, string name, string gender, string phone, string address)
        {
            try
            {
                var user = Eshtrydb.Users.FirstOrDefault(x => x.UserID == userid);
                user.UserName = name;
                user.Gender = gender;
                user.PhoneNumber = phone;
                user.Address = address;
                Eshtrydb.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }

}

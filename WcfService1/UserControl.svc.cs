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

        public string[][] ListItems()
        {
            try
            {
                List<Item> items = Eshtrydb.Items.ToList();

                string[][] jaggedItems = new string[items.Count][];

                int i = 0;
                foreach (var Item in items)
                {
                    jaggedItems[i] = new string[] {
                    Item.ItemID.ToString(),
                    Item.ItemImage,
                    Item.ItemTittle,
                    Item.ItemDescription,
                    Item.Price.ToString(),
                    Item.ItemQuantity.ToString(),
                    Item.Seller,
                    Item.Category.CategoryName
                };
                    i++;
                }

                return jaggedItems;

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

        public string[][] Viewcart(int UserID)
        {
            //Last array index is the total price

            Order order = Eshtrydb.Orders.FirstOrDefault(x => x.User.UserID == UserID && x.state == 1);

            var orderItems = Eshtrydb.OrderItems.Where(x => x.OrderID == order.OrderID).ToList();

            string[][] jaggedorderItems = new string[orderItems.Count+1][];
            int i = 0;
            foreach (var Item in orderItems)
            {
                //zabtha
                if (Item.Item.ItemQuantity >= Item.Quantity)
                {
                    jaggedorderItems[i] = new string[] {
                    Item.Item.ItemID.ToString(),
                    Item.Item.ItemTittle,
                    Item.Quantity.ToString(),
                    Item.Item.Price.ToString(),
                    Item.Item.ItemImage,
                    Item.Item.ItemQuantity.ToString(),
                    };
                    i++;
                }
                else
                {
                    jaggedorderItems[i] = new string[] {
                    Item.Item.ItemID.ToString(),
                    Item.Item.ItemTittle,
                    Item.Item.ItemQuantity.ToString(), //changed quantity
                    Item.Item.Price.ToString(),
                    Item.Item.ItemImage,
                    Item.Item.ItemQuantity.ToString(),
                    };
                    i++;
                    order.TotalPrice -= (Item.Quantity - Item.Item.ItemQuantity) * Item.Item.Price;
                }
               
            }
            jaggedorderItems[i] = new string[] { order.TotalPrice.ToString() };
            
            return jaggedorderItems;
        }

        //Not Tested Yet
        /*
            date of order then items of order then total price in a loop
        [to know the total price search for (string[i].length == 1  && string[i+1].length == 1 &&  i+1 < string.count)] then a new order starts
        */
        public string[][] getDeleviredOrders(int userid)
        {
            var orders = Eshtrydb.Orders.Where(x => x.User.UserID == userid && x.state == -1).ToList();
            int quantity = 0;
            foreach (var order in orders)
            {
                var oi = Eshtrydb.OrderItems.Where(x => x.OrderID == order.OrderID).ToList();
                quantity += oi.Count;
            }
            string[][] jaggedItems = new string[quantity + 4 * orders.Count + 1][];
            int i = 0;
            foreach (var order in orders)
            {
                var orderItems = Eshtrydb.OrderItems.Where(x => x.OrderID == order.OrderID).ToList();
                jaggedItems[i] = new string[] { "." };
                i++;
                jaggedItems[i] = new string[] { order.OrderID.ToString() };
                i++;
                jaggedItems[i] = new string[] { order.OrderDate.ToString() };
                i++;
                jaggedItems[i] = new string[] { order.TotalPrice.ToString() };
                i++;
                foreach (var Item in orderItems)
                {
                    jaggedItems[i] = new string[] {
                    Item.Item.ItemTittle,
                    Item.Quantity.ToString(),
                    Item.Item.Price.ToString(),
                    Item.Item.ItemImage,
                    };
                    i++;
                }
                jaggedItems[i] = new string[] {"." };
            }

            return jaggedItems;
        }

        //Not Tested Yet
        /*
            date of order then items of order then total price in a loop
        [to know the total price search for (string[i].length == 1  && string[i+1].length == 1 &&  i+1 < string.count)] then a new order starts
        */
        public string[][] getDeleviringOrders(int userid)
        {
            var orders = Eshtrydb.Orders.Where(x => x.User.UserID == userid && x.state == 0).ToList();
            int quantity = 0;
            foreach (var order in orders)
            {
                var oi = Eshtrydb.OrderItems.Where(x => x.OrderID == order.OrderID).ToList();
                 quantity += oi.Count;
            }
            string[][] jaggedItems = new string[quantity + 4 * orders.Count + 1][];
            int i = 0;
            foreach (var order in orders)
            {
                var orderItems = Eshtrydb.OrderItems.Where(x => x.OrderID == order.OrderID).ToList();
                jaggedItems[i] = new string[] { "." };
                i++;
                jaggedItems[i] = new string[] { order.OrderID.ToString() };
                i++;
                jaggedItems[i] = new string[] { order.OrderDate.ToString() };
                i++;
                jaggedItems[i] = new string[] { order.TotalPrice.ToString() };
                i++;
                foreach (var Item in orderItems)
                {
                    jaggedItems[i] = new string[] {
                    Item.Item.ItemTittle,
                    Item.Quantity.ToString(),
                    Item.Item.Price.ToString(),
                    Item.Item.ItemImage,
                    };
                    i++;
                }
                jaggedItems[i] = new string[] { "." };
            }

            return jaggedItems;
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

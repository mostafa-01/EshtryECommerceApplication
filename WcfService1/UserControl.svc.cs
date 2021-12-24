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

                Eshtrydb.OrderItems.Add(orderItem);
                //Eshtrydb.SaveChanges();
            }
            else
            {
                orderItem.Quantity += Quantity;

                //Eshtrydb.SaveChanges();
            }

            order.TotalPrice += item.Price * Quantity;

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

        public void Removefromcart(int ItemID, int UserID, int Quantity)
        {
            Order order = Eshtrydb.Orders.FirstOrDefault(x => x.User.UserID == UserID && x.state == 1);

            Item item = Eshtrydb.Items.FirstOrDefault(x => x.ItemID == ItemID);

            OrderItem orderItem = Eshtrydb.OrderItems.FirstOrDefault(x => x.ItemID == ItemID && x.OrderID == order.OrderID);
            orderItem.Quantity -= Quantity;
            if (orderItem.Quantity <= 0)
            {
                Eshtrydb.OrderItems.Remove(orderItem);
            }

                //Eshtrydb.SaveChanges();

            order.TotalPrice -= item.Price * Quantity;

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
                    Item.Item.ItemTittle,
                    Item.Item.Price.ToString(),
                    Item.Quantity.ToString(),
                    };
                    i++;
                }
                else
                {
                    jaggedorderItems[i] = new string[] {
                    Item.Item.ItemTittle,
                    Item.Item.Price.ToString(),
                    Item.Item.ItemQuantity.ToString() + " (Quantity has been changed)",
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
            string[][] jaggedItems = new string[orders.Count + 2 * orders.Count + 1][];
            int i = 0;
            foreach (var order in orders)
            {
                var orderItems = Eshtrydb.OrderItems.Where(x => x.OrderID == order.OrderID).ToList();
                jaggedItems[i] = new string[] { order.OrderDate.ToString() };
                i++;
                foreach (var Item in orderItems)
                {
                    jaggedItems[i] = new string[] {
                    Item.Item.ItemTittle,
                    Item.Item.Price.ToString(),
                    Item.Quantity.ToString(),
                    };
                    i++;
                }
                jaggedItems[i] = new string[] { order.TotalPrice.ToString() };
                i++;
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
            string[][] jaggedItems = new string[orders.Count + 2 * orders.Count + 1][];
            int i = 0;
            foreach (var order in orders)
            {
                var orderItems = Eshtrydb.OrderItems.Where(x => x.OrderID == order.OrderID).ToList();
                jaggedItems[i] = new string[] { order.OrderDate.ToString() };
                i++;
                foreach (var Item in orderItems)
                {
                    jaggedItems[i] = new string[] {
                    Item.Item.ItemTittle,
                    Item.Item.Price.ToString(),
                    Item.Quantity.ToString(),
                    };
                    i++;
                }
                jaggedItems[i] = new string[] { order.TotalPrice.ToString() };
                i++;
            }

            return jaggedItems;
        }

        public float Checkout(int userid)
        {
            Order order = Eshtrydb.Orders.FirstOrDefault(x => x.User.UserID == userid && x.state == 1);
            order.OrderDate = DateTime.Now;
            order.state = 0;
            var orderItems = Eshtrydb.OrderItems.Where(x => x.OrderID == order.OrderID).ToList();
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
    }

}

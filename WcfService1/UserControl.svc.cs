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


        public List<string> ListItems()
        {
            try
            {
                List<Item> items = Eshtrydb.Items.ToList();

                List<string> ItemsList = new List<string>();

                string ItemData = null;

                foreach (var Item in items)
                {
                    ItemData += Item.ItemID.ToString();
                    ItemData += ",";

                    ItemData += Item.ItemTittle;
                    ItemData += ",";

                    ItemData += Item.ItemDescription;
                    ItemData += ",";

                    ItemData += Item.ItemQuantity.ToString();
                    ItemData += ",";

                    ItemData += Item.ItemImage;
                    ItemData += ",";

                    ItemData += Item.Price.ToString();
                    ItemData += ",";

                    ItemData += Item.Seller;
                    ItemData += ",";

                    ItemData += Item.Category.CategoryName;

                    ItemsList.Add(ItemData);

                    ItemData = null;

                }

                return ItemsList;

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

        public List<string> Viewcart(int UserID)
        {
            /*
             if string start with '#' then its totalprice
             */

            Order order = Eshtrydb.Orders.FirstOrDefault(x => x.User.UserID == UserID && x.state == 1);

            var orderItems = Eshtrydb.OrderItems.Where(x => x.OrderID == order.OrderID).ToList();

            List<string> ItemsList = new List<string>();

            string ItemData = null;

            foreach (var Item in orderItems)
            {
                ItemData += Item.Item.ItemTittle;
                ItemData += ",";

                ItemData += Item.Item.Price.ToString();
                ItemData += ",";

                ItemData += Item.Quantity.ToString();
                ItemData += ",";

                ItemsList.Add(ItemData);

                ItemData = null;
            }

            ItemData = '#' + order.TotalPrice.ToString();
            ItemsList.Add(ItemData);
            return ItemsList;
        }

        //Not Tested Yet
        /*
             if string start with '#' then its totalprice and if starts with '$' then its date of order
        */
        public List<string> getDeleviredOrders(int userid)
        {
            var orders = Eshtrydb.Orders.Where(x => x.User.UserID == userid && x.state == -1).ToList();
            List<string> ItemsList = new List<string>();
            foreach (var order in orders) {
                var orderItems = Eshtrydb.OrderItems.Where(x => x.OrderID == order.OrderID).ToList();


                string ItemData = null;

                foreach (var Item in orderItems)
                {
                    ItemData += Item.Item.ItemTittle;
                    ItemData += ",";

                    ItemData += Item.Item.Price.ToString();
                    ItemData += ",";

                    ItemData += Item.Quantity.ToString();
                    ItemData += ",";

                    ItemsList.Add(ItemData);

                    ItemData = null;
                }

                ItemsList.Add('#' + order.TotalPrice.ToString());
                ItemsList.Add ('$' + order.OrderDate.ToString());
            }
            return ItemsList;
        }

        //Not Tested Yet
        /*
              if string start with '#' then its totalprice and if starts with '$' then its date of order
         */
        public List<string> getDeleviringOrders(int userid)
        {
            var orders = Eshtrydb.Orders.Where(x => x.User.UserID == userid && x.state == 0).ToList();
            List<string> ItemsList = new List<string>();
            foreach (var order in orders)
            {
                var orderItems = Eshtrydb.OrderItems.Where(x => x.OrderID == order.OrderID).ToList();


                string ItemData = null;

                foreach (var Item in orderItems)
                {
                    ItemData += Item.Item.ItemTittle;
                    ItemData += ",";

                    ItemData += Item.Item.Price.ToString();
                    ItemData += ",";

                    ItemData += Item.Quantity.ToString();
                    ItemData += ",";

                    ItemsList.Add(ItemData);

                    ItemData = null;
                }

                ItemsList.Add('#' + order.TotalPrice.ToString());
                ItemsList.Add('$' + order.OrderDate.ToString());
            }
            return ItemsList;
        }
    }
}

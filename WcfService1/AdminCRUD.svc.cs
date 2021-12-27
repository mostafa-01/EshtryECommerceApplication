using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Eshtry;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminCRUD" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdminCRUD.svc or AdminCRUD.svc.cs at the Solution Explorer and start debugging.
    public class AdminCRUD : IAdminCRUD
    {
        EshtryDBContext EC = new EshtryDBContext();
        public void DoWork()
        {
        }
        
        //Create
        public bool AddCategory(string CatTittle)
        {
            try
            {

                Category category = new Category();

                category.CategoryName = CatTittle;

                EC.Categories.Add(category);
                EC.SaveChanges();

                return true;
            }catch(Exception ex)
            {
                Console.Write(ex);
                return false;
            }
        }

        //Create
        public bool AddItem(string tittle, string description, string image, int quantity, 
            float price, string seller, int CategoryID)
        {
            try
            {
                Item Item = new Item();

                Item.ItemTittle = tittle;
                Item.ItemDescription = description;
                Item.ItemImage = image;
                Item.ItemQuantity = quantity;
                Item.Price = price;
                Item.Seller = seller;
                Item.Category= EC.Categories.FirstOrDefault(x => x.CategoryID == CategoryID);

                EC.Items.Add(Item);
                EC.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }

        }

        //Read
        public string[] getItem(int itemid)
        {
            try
            {
                var Item = EC.Items.FirstOrDefault(x => x.ItemID == itemid);
                if(Item == null)
                {
                    return null;
                }
                else
                {
                    string[] returnedItem = { 
                    Item.ItemID.ToString(),
                    Item.ItemImage,
                    Item.ItemTittle,
                    Item.ItemDescription,
                    Item.Price.ToString(),
                    Item.ItemQuantity.ToString(),
                    Item.Seller,
                    EC.Categories.FirstOrDefault(x => x.CategoryID == Item.Category.CategoryID).CategoryName
                };

                return returnedItem;
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }

        }

        //Update
        public string EditItem(int id, string tittle, string description, string image, int quantity,
            float price, string seller, int CategoryID)
        {
            try
            {
                var Item = EC.Items.FirstOrDefault(x => x.ItemID == id);
                bool deleted = this.DeleteItem(Item.ItemID);

                if (deleted)
                {
                    this.AddItem(tittle,description,image,quantity,price,seller,CategoryID);
                    EC.SaveChanges();
                    return "Item Updated Succ.";
                }
                else
                {
                    return "Error Happened While Updating Item...";
                }

                //if(Item == null)
                //{
                //    return "This Item ID is not registered in the DataBase";
                //}
                //else
                //{
                //        Item.ItemTittle         = tittle;
                //        Item.ItemDescription    = description;
                //        Item.ItemImage          = image;
                //        Item.ItemQuantity       = quantity;
                //        Item.Price              = price;
                //        Item.Seller             = seller;
                //        Item.Category           = EC.Categories.FirstOrDefault(x => x.CategoryID == CategoryID);

                //}

            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return "Exception is thrown.";
            }

        }

        //Delete
        public bool DeleteItem(int itemid)
        {
            try
            {
                var item = EC.Items.FirstOrDefault(x => x.ItemID == itemid);

                item.ItemQuantity = 0;

                var orderitems = EC.OrderItems.Where(x => x.ItemID == item.ItemID).ToList();

                foreach(var OT in orderitems)
                {
                    if (OT.Order.state == 1)
                    {
                        OT.Order.TotalPrice -= EC.Items.FirstOrDefault(x => x.ItemID == OT.ItemID).Price * OT.Quantity; 
                        EC.OrderItems.Remove(OT);
                    }
                }

                EC.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }

        }
    }
}

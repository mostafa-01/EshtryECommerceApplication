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

                category.CategoryID = EC.Categories.Max(x => x.CategoryID) + 1;
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
                if(EC.Items.Count() == 0)
                {
                    Item.ItemID = 1;
                }else
                {
                    Item.ItemID = EC.Items.Max(x => x.ItemID) + 1;
                }

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
        public string getItem(int itemid)
        {
            try
            {
                string Item = null;

                var item = EC.Items.FirstOrDefault(x => x.ItemID == itemid);
                if(item == null)
                {
                    return "No,Item,Found, , , , ";
                }
                else
                {
                    Item += item.ItemTittle;
                    Item += ",";
                    Item += item.ItemDescription;
                    Item += ",";
                    Item += item.ItemImage;
                    Item += ",";
                    Item += item.ItemQuantity.ToString();
                    Item += ",";
                    Item += item.Price.ToString();
                    Item += ",";
                    Item += item.Seller;
                    Item += ",";
                    Item += EC.Categories.FirstOrDefault(x => x.CategoryID == item.Category.CategoryID).CategoryName;
                    
                }

                return Item;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return " ";
            }

        }

        //Update
        public string EditItem(int id, string tittle, string description, string image, int quantity,
            float price, string seller, int CategoryID)
        {
            try
            {
                var Item = EC.Items.FirstOrDefault(x => x.ItemID == id);
                if(Item == null)
                {
                    return "This Item ID is not registered in the DataBase";
                }
                else
                {
                        Item.ItemTittle         = tittle;
                        Item.ItemDescription    = description;
                        Item.ItemImage          = image;
                        Item.ItemQuantity       = quantity;
                        Item.Price              = price;
                        Item.Seller             = seller;
                        Item.Category           = EC.Categories.FirstOrDefault(x => x.CategoryID == CategoryID);

                    EC.SaveChanges();
                }

                return "Item Updated Succ.";
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

                EC.Items.Remove(item);

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

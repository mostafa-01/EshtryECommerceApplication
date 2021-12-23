using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Eshtry;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Search" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Search.svc or Search.svc.cs at the Solution Explorer and start debugging.
    public class Search : ISearch
    {

        EshtryDBContext Eshtrydb = new EshtryDBContext();

        public void DoWork()
        {
        }


        public List<string> FilterItemsInCategory(int CategoryID)
        {
            /*
                This methode returns a list of strings, each string represent an item
                ItemData is Concatenated in the string with "," seperates each item attribute from the other.
                To get Each Item Attribute Use This Code:

                 List<Item> itemslist = new List<Item>();
                 foreach (string item in ItemsList)
                {
                    string[] ItemDataMember = item.Split(',');
                    Item Item = new Item();

                    Item.ItemID = int.Parse(ItemDataMember[0]);
                    Item.ItemTittle = ItemDataMember[1];
                    Item.ItemDescription = ItemDataMember[2];
                    Item.ItemQuantity = int.Parse(ItemDataMember[3]);
                    Item.ItemImage = ItemDataMember[4];
                    Item.Price = float.Parse(ItemDataMember[6]);
                    Item.Seller = ItemDataMember[5];
                    Item.Category.CategoryName =  ItemDataMember[7];
                    
                    itemlist.Add(Item);
                }
                
                
             */
            List<Item> items = Eshtrydb.Categories.FirstOrDefault(x => x.CategoryID == CategoryID).Items.ToList();

            List<string> ItemsList = new List<string>();

            string ItemData = null;

            foreach(var Item in items)
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

        public List<string> getCategories()
        {
            try
            {
                List<string> Categories = new List<string>();

                Categories.AddRange(Eshtrydb.Categories.Select(x => x.CategoryName).ToList());

                return Categories;

            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        //Use live editing with it in front end
        public List<string> Recomendations(string PartOfItemName)
        {
            var RecommendedItems = Eshtrydb.Items.Where(x => x.ItemTittle.Contains(PartOfItemName)).ToList();

            List<string> RecommendedItemsNames = new List<string>();

            RecommendedItemsNames.AddRange(RecommendedItems.Select(x => x.ItemTittle).ToList());

            return RecommendedItemsNames;
        }

        public List<string> SearchByItemName(string ItemName)
        {
            List<Item> items = Eshtrydb.Items.Where(x => x.ItemTittle.Contains(ItemName) || x.ItemTittle.Equals(ItemName)).ToList();

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

    }
}

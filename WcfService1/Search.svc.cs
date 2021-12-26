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


        public string[][] FilterItemsInCategory(string CategoryName)
        {

            List<Item> items = Eshtrydb.Categories.FirstOrDefault(x => x.CategoryName == CategoryName).Items.ToList();
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

        public string[][] SearchByItemName(string ItemName,string CategoryName)
        {
            List<Item> items;
            if (CategoryName == "All")
            {
                 items = Eshtrydb.Items.Where(x => x.ItemTittle.Contains(ItemName) || x.ItemTittle.Equals(ItemName)).ToList();
            }
            else
            {
                 items = Eshtrydb.Items.Where(x =>(x.ItemTittle.Contains(ItemName) || x.ItemTittle.Equals(ItemName)) && x.Category.CategoryName.Equals(CategoryName)).ToList();

            }

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

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eshtry
{
    public class EshtryDBInit : DropCreateDatabaseIfModelChanges<EshtryDBContext>
    {
        protected override void Seed(EshtryDBContext context)
        {
            IList<Category> Categories = new List<Category>();

            Categories.Add(new Category() { CategoryID =  1 , CategoryName = "Fashion"});
            Categories.Add(new Category() { CategoryID =  2 , CategoryName = "SuperMarket"});
            Categories.Add(new Category() { CategoryID =  3 , CategoryName = "Electronics"});
            Categories.Add(new Category() { CategoryID =  4 , CategoryName = "Gaming"});
            Categories.Add(new Category() { CategoryID =  5 , CategoryName = "Sport"});

            context.Categories.AddRange(Categories);

            IList<User> Users = new List<User>();

            Users.Add(new User() {
                UserID = 1,
                Password = "123123",
                Age = 22,
                Gender = "Male",
                UserName= "Andrew",
                Address ="Nasr City",
                PhoneNumber = "01110281318",
                Email = "andrew@gmail.com"
            });
            Users.Add(new User()
            {
                UserID = 2,
                Password = "123123",
                Age = 22,
                Gender = "Male",
                UserName = "Mostafa",
                Address = "Nasr City",
                PhoneNumber = "01149415599",
                Email = "mostafa@gmail.com"
            });
            Users.Add(new User()
            {
                UserID = 3,
                Password = "123123",
                Age = 22,
                Gender = "Female",
                UserName = "Nada",
                Address = "1st Settlement",
                PhoneNumber = "01204324078",
                Email = "nada@gmail.com"
            });

            context.Users.AddRange(Users);

            IList<Order> Orders = new List<Order>();

            Orders.Add(new Order() { 
                OrderID = 1,
                OrderDate = null,
                state = 1,
                TotalPrice = 1050,
                User = Users[0]
            });
            Orders.Add(new Order()
            {
                OrderID = 2,
                OrderDate = new DateTime(2021,12,21),
                state = 0,
                TotalPrice = 850,
                User = Users[0]
            });
            Orders.Add(new Order()
            {
                OrderID = 3,
                OrderDate = new DateTime(2021, 12, 22),
                state = 0,
                TotalPrice = 100,
                User = Users[0]
            });
            Orders.Add(new Order()
            {
                OrderID = 4,
                OrderDate = new DateTime(2021, 12, 20),
                state = -1,
                TotalPrice = 600,
                User = Users[0]
            });
            Orders.Add(new Order()
            {
                OrderID = 5,
                OrderDate = null,
                state = 1,
                TotalPrice = 0,
                User = Users[1]
            });
            Orders.Add(new Order()
            {
                OrderID = 6,
                OrderDate = null,
                state = 1,
                TotalPrice = 0,
                User = Users[2]
            });

            context.Orders.AddRange(Orders);


            
            IList<Item> Items = new List<Item>();

            Items.Add(new Item()
            {
                ItemID = 1,
                ItemImage = "Gazma.png",
                ItemTittle = "Gazma",
                ItemDescription = "Its cool you can wear it on your feet",
                Price = 200,
                ItemQuantity = 15,
                Seller = "Andrew",
                Category = Categories[0],
            });
            Items.Add(new Item()
            {
                ItemID = 2,
                ItemImage = "Sharab.png",
                ItemTittle = "Sharab",
                ItemDescription = "Its cool you can wear it between your feet and your shoes",
                Price = 50,
                ItemQuantity = 30,
                Seller = "Andrew",
                Category = Categories[0],
            });
            Items.Add(new Item()
            {
                ItemID = 3,
                ItemImage = "Nadara",
                ItemTittle = "Nadara",
                ItemDescription = "Its cool you can wear it on your eyes",
                Price = 450,
                ItemQuantity = 10,
                Seller = "Nada",
                Category = Categories[0],
            });

            context.Items.AddRange(Items);

            IList<OrderItem> OrderItems = new List<OrderItem>();

            OrderItems.Add(new OrderItem()
            {
                OrderID = 1,
                ItemID = 1,
                Quantity = 5,
            });
            OrderItems.Add(new OrderItem()
            {
                OrderID = 1,
                ItemID = 2,
                Quantity = 1,
            });
            OrderItems.Add(new OrderItem()
            {
                OrderID = 2,
                ItemID = 1,
                Quantity = 3,
            });
            OrderItems.Add(new OrderItem()
            {
                OrderID = 2,
                ItemID = 2,
                Quantity = 5,
            });
            OrderItems.Add(new OrderItem()
            {
                OrderID = 3,
                ItemID = 2,
                Quantity = 2,
            });
            OrderItems.Add(new OrderItem()
            {
                OrderID = 4,
                ItemID = 1,
                Quantity = 3,
            });

            context.OrderItems.AddRange(OrderItems);

            base.Seed(context);
        }
    }
}
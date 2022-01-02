using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eshtry
{
    public class EshtryDBInit : DropCreateDatabaseIfModelChanges<EshtryDBContext>
    {
        void AddItem(int ItemID, string Image, string Title, string Description, float Price, int Quantity, string Seller, Category Category , IList<Item> Items)
        {
            Items.Add(new Item()
            {   ItemID = ItemID,
                ItemImage = Image,
                ItemTittle = Title,
                ItemDescription = Description,
                Price = Price,
                ItemQuantity = Quantity,
                Seller = Seller,
                Category = Category,
            });
        }
        protected override void Seed(EshtryDBContext context)
        {
            IList<Category> Categories = new List<Category>();

            Categories.Add(new Category() { CategoryID =  1 , CategoryName = "Fashion"});
            Categories.Add(new Category() { CategoryID =  2 , CategoryName = "SuperMarket"});
            Categories.Add(new Category() { CategoryID =  3 , CategoryName = "Electronics"});
            Categories.Add(new Category() { CategoryID =  4 , CategoryName = "Health & Beauty"});
            Categories.Add(new Category() { CategoryID =  5 , CategoryName = "Sporting"});

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
            Users.Add(new User()
            {
                UserID = 4,
                Password = "123123",
                Age = 22,
                Gender = "Female",
                UserName = "Maryam",
                Address = "Masr el gdeda",
                PhoneNumber = "0111111111",
                Email = "Maryam@gmail.com"
            });
            Users.Add(new User()
            {
                UserID = 5,
                Password = "123123",
                Age = 22,
                Gender = "Female",
                UserName = "Monica",
                Address = "El Daher",
                PhoneNumber = "0112222222",
                Email = "Monica@gmail.com"
            });

            context.Users.AddRange(Users);

            IList<Order> Orders = new List<Order>();

            Orders.Add(new Order() { 
                OrderID = 1,
                OrderDate = null,
                state = 1,
                TotalPrice = 0,
                User = Users[0]
            });
            Orders.Add(new Order()
            {
                OrderID = 2,
                OrderDate = null,
                state = 1,
                TotalPrice = 0,
                User = Users[1]
            });
            Orders.Add(new Order()
            {
                OrderID = 3,
                OrderDate = null,
                state = 1,
                TotalPrice = 0,
                User = Users[2]
            });
            Orders.Add(new Order()
            {
                OrderID = 4,
                OrderDate = null,
                state = 1,
                TotalPrice = 0,
                User = Users[3]
            });
            Orders.Add(new Order()
            {
                OrderID = 5,
                OrderDate = null,
                state = 1,
                TotalPrice = 0,
                User = Users[4]
            });

            context.Orders.AddRange(Orders);


            
            IList<Item> Items = new List<Item>();
            AddItem(1, "Shirt.png", "Shirt", "Shirt Description, Write a description here.", 17.99f, 100, "Andrew", Categories[0],Items);
            AddItem(2, "Shoes.png", "Shoes", "Shoes Description, Write a description here.", 27.99f, 100, "Andrew", Categories[0], Items);
            AddItem(3, "Jeans.png", "Jeans", "Jeans Description, Write a description here.", 15.99f, 100, "Andrew", Categories[0], Items);
            AddItem(4, "Sweatpants.png", "Sweatpants", "Sweatpants Description, Write a description here.", 12.99f, 100, "Andrew", Categories[0], Items);
            AddItem(5, "Watch.png", "Watch", "Watch Description, Write a description here.", 227.99f, 100, "Andrew", Categories[0], Items);


            AddItem(6, "Chipsy.png", "Chipsy", "Chipsy Description, Write a description here.", 5.99f, 100, "Andrew", Categories[1], Items);
            AddItem(7, "Pepsi.png", "Pepsi", "Pepsi Description, Write a description here.", 2.99f, 100, "Andrew", Categories[1], Items);
            AddItem(8, "Molto.png", "Molto", "Molto Description, Write a description here.", 1.99f, 100, "Andrew", Categories[1], Items);
            AddItem(9, "Gum.png", "Gum", "Gum Description, Write a description here.", 1.99f, 100, "Andrew", Categories[1], Items);
            AddItem(10, "Biscuit.jpg", "Biscuit", "Biscuit Description, Write a description here.", 3.99f, 100, "Andrew", Categories[1], Items);

            AddItem(11, "TV.png", "TV", "TV Description, Write a description here.", 3999.99f, 100, "Andrew", Categories[2], Items);
            AddItem(12, "Case.png", "Pc Case", "Pc Case Description, Write a description here.", 499.99f, 100, "Andrew", Categories[2], Items);
            AddItem(13, "Laptop.png", "Laptop", "Laptop Description, Write a description here.", 1999.99f, 100, "Andrew", Categories[2], Items);
            AddItem(14, "Keyboard.png", "Keyboard", "Keyboard Description, Write a description here.", 59.99f, 100, "Andrew", Categories[2], Items);
            AddItem(15, "Mouse.png", "Mouse", "Mouse Description, Write a description here.", 49.99f, 100, "Andrew", Categories[2], Items);

            AddItem(16, "Shampoo.png", "Shampoo", "Shampoo Description, Write a description here.", 19.99f, 100, "Andrew", Categories[3], Items);
            AddItem(17, "EyeLiner.png", "EyeLiner", "EyeLiner Description, Write a description here.", 99.99f, 100, "Andrew", Categories[3], Items);
            AddItem(18, "Lipstick.png", "Lipstick", "Lipstick Description, Write a description here.", 59.99f, 100, "Andrew", Categories[3], Items);
            AddItem(19, "EyeShadow.png", "EyeShadow", "EyeShadow Description, Write a description here.", 69.99f, 100, "Andrew", Categories[3], Items);
            AddItem(20, "BeardTrimmer.png", "BeardTrimmer", "BeardTrimmer Description, Write a description here.", 199.99f, 100, "Andrew", Categories[3], Items);

            AddItem(21, "Dumbbells.png", "Dumbbells", "Dumbbells Description, Write a description here.", 29.99f, 100, "Andrew", Categories[4], Items);
            AddItem(22, "Treadmill.png", "Treadmill", "Treadmill Description, Write a description here.", 4999.99f, 100, "Andrew", Categories[4], Items);
            AddItem(23, "Gloves.png", "Gloves", "Gloves Description, Write a description here.", 39.99f, 100, "Andrew", Categories[4], Items);
            AddItem(24, "YogaMat.png", "YogaMat", "YogaMat Description, Write a description here.", 29.99f, 100, "Andrew", Categories[4], Items);
            AddItem(25, "BattleRope.png", "BattleRope", "BattleRope Description, Write a description here.", 19, 100, "Andrew", Categories[4], Items);


            context.Items.AddRange(Items);

            base.Seed(context);
        }
    }
}
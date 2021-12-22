using System;
using System.Data.Entity;
using System.Linq;

namespace Eshtry
{
    public class EshtryDBContext : DbContext
    {
        // Your context has been configured to use a 'EshtryDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Eshtry.EshtryDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EshtryDBContext' 
        // connection string in the application configuration file.
        public EshtryDBContext()
            : base("name=EshtryDBContext")
        {
            Database.SetInitializer<EshtryDBContext>(new EshtryDBInit());
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
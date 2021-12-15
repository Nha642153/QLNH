using Microsoft.EntityFrameworkCore;
using QuanlyNhahang_API.Model;

namespace QuanlyNhahang_API.Data
{

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemImage> ItemImage { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryType> CategoryType { get; set; }
        public DbSet<Guest> Guest { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<UnitType> UnitType { get; set; }
        public DbSet<Status> Status { get; set; }
 

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = string.Format(@"Data Source=DESKTOP-TG0HR75\THANHNHA;Initial Catalog=BBQ_House;Integrated Security=True");
            options.UseSqlServer(connectionString);
        }
    }

}

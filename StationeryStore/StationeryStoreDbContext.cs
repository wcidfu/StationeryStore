using Microsoft.EntityFrameworkCore;
using StationeryStore.Entities;

namespace StationeryStore
{
    class StationeryStoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=1327q;Database=trade_db");
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

    }

}

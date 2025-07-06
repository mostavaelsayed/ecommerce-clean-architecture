using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataPersistence.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext()
        {
        }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}

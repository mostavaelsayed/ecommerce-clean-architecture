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

        // Define DbSet properties for your entities
         public DbSet<Order> Orders { get; set;  }
    }
}

using Microsoft.EntityFrameworkCore;
using ProjectOrder.Domain.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace ProjectOrder.Infra.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Order> Orders { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Customer> Customers { get; set; }
    }
}
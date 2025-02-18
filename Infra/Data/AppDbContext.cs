using Microsoft.EntityFrameworkCore;
using ProjectOrder.Domain.Entity;

namespace ProjectOrder.Infra.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Costumer> Costumers { get; set; }
}

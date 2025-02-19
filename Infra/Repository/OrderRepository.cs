using Microsoft.EntityFrameworkCore;
using ProjectOrder.Domain.Entity;
using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.Data;

namespace ProjectOrder.Infra.Repository;

public class OrderRepository(AppDbContext context) : IOrderRepository
{
    public async Task<Order?> GetOrderByIdAsync(int orderId)
    { 
       return await context.Orders.FindAsync(orderId);
    }
    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await context.Orders.ToListAsync();
    }
    public async Task AddOrder(Order order)
    { 
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
    }
    public async Task UpdateOrder(Order order)
    {
        context.Orders.Update(order);
        await context.SaveChangesAsync();
    }
    public async Task DeleteOrder(Order order)
    {
        context.Orders.Remove(order);
        await context.SaveChangesAsync();
    }
    
}
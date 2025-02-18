using System.Data.Entity;
using ProjectOrder.Domain.Entity;
using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.Data;

namespace ProjectOrder.Infra.Repository;

public class OrderRepository(AppDbContext context) : IOrderRepository
{
    public async Task<Order> GetOrderByIAync(int orderId)
    {
       return (await context.Orders.FindAsync(orderId))!;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await context.Orders.ToListAsync();
    }
    
    public void AddOrder(Order order)
    { 
        context.Orders.AddAsync(order);
    }
    public void UpdateOrder(Order order)
    {
        context.Orders.Update(order);
    }
    public void DeleteOrder(Order order)
    {
        context.Orders.Remove(order);
    }
    
}
using ProjectOrder.Domain.Entity;

namespace ProjectOrder.Domain.Repository;

public interface IOrderRepository
{
    Task<Order?> GetOrderByIdAsync(int orderId);
    Task<IEnumerable<Order>> GetAllAsync();
    Task AddOrder(Order order);
    Task UpdateOrder(Order order);
    Task DeleteOrder(Order order);
}
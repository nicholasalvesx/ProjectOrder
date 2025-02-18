using ProjectOrder.Domain.Entity;

namespace ProjectOrder.Domain.Repository;

public interface IOrderRepository
{
    Task<Order> GetOrderByIAync(int orderId);
    Task<IEnumerable<Order>> GetAllAsync();
    void AddOrder(Order order);
    void UpdateOrder(Order order);
    void DeleteOrder(Order order);
}
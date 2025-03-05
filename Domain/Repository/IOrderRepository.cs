using ProjectOrder.Domain.Entity;

namespace ProjectOrder.Domain.Repository;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync();
    void AddOrder(Order order);
}
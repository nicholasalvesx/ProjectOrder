using ProjectOrder.Domain.Entity;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Application.Commands;

public class CreateOrderCommand
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public async Task<bool> ExecuteAsync(IUnitOfWork unitOfWork)
    {
        var order = new Order(CustomerId, ProductId, Quantity);

        await unitOfWork.Orders.AddOrder(order);
        await unitOfWork.CommitAsync();

        return true;
    }
}
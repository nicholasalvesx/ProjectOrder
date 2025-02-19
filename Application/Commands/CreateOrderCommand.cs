using MediatR;

namespace ProjectOrder.Application.Commands;
public class CreateOrderCommand : IRequest<bool>
{ 
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public decimal Quantity { get; set; }

    public CreateOrderCommand(int customerId)
    {
        CustomerId = customerId;
    }
}
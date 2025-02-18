using MediatR;

namespace ProjectOrder.Application.Commands;
public class CreateOrderCommand : IRequest<bool>
{ 
    public int CustomerId { get; set; }
    public int OrderId { get; set; }
    public List<int> ProductIds { get; set; }

    public CreateOrderCommand(int customerId, List<int> productIds)
    {
        CustomerId = customerId;
        ProductIds = productIds;
    }
}
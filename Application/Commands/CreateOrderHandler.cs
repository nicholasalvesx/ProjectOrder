using MediatR;
using ProjectOrder.Application.Services;
using ProjectOrder.Domain.Entity;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Application.Commands;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order(request.CustomerId, request.ProductId, request.Quantity);
            
        await _unitOfWork.Orders.AddOrder(order);
        
        await _unitOfWork.CommitAsync();
        return true;
    }
}
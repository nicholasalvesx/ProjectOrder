using MediatR;
using ProjectOrder.Application.Services;
using ProjectOrder.Domain.Entity;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Application.Commands;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;

    public CreateOrderHandler(IUnitOfWork unitOfWork, IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _emailService = emailService;
    }

    public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            CostumerId = request.CustomerId,
            OrderDate = DateTime.Now,
        };
        _unitOfWork.Orders.AddOrder(order);

        foreach (var productId in request.ProductIds)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            if (product == null! || product.Stock <= 0)
                return false;

            product.Stock--;
            _unitOfWork.Products.UpdateProduct(product);
        }
        await _unitOfWork.CommitAsync();
        await _emailService.SendOrderEmailVerficationAsync(request.CustomerId, request.OrderId);
        return true;
    }
}
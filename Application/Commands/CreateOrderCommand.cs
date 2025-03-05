using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Application.Commands;

public class CreateOrderCommand
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderCommand(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
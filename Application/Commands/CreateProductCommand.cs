using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Application.Commands;

public class CreateProductCommand
{  
    private readonly IUnitOfWork _unitOfWork;
    public string? Name { get; set; }
    public decimal Price { get; set; }

    public CreateProductCommand(string? name, decimal price, UnitOfWork unitOfWork)
    {
        Name = name;
        Price = price;
        _unitOfWork = unitOfWork;
    }
}
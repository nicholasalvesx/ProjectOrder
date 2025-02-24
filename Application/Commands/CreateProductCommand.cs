using System.Diagnostics;
using ProjectOrder.Domain.Entity;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Application.Commands;

public class CreateProductCommand
{  
    public string? Name { get; set; }
    public decimal Price { get; set; }

    public async Task<bool> ExecutAsync(IUnitOfWork unitOfWork)
    {
        Debug.Assert(Name != null, nameof(Name) + " != null");
        var product = new Product(Name, Price);
        
        await unitOfWork.Products.AddProduct(product);
        await unitOfWork.CommitAsync();
        
        return true;
    }
}
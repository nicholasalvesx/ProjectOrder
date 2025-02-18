using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Entity;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages;

public class ProductModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public List<Product> Products { get; set; } = new();

    public async Task OnGetAsync()
    {
        Products = (List<Product>)await _unitOfWork.Products.GetAllAsync();
    }
    
}
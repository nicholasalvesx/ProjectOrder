using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Product;

public class ProductModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public List<Domain.Entity.Product>? Product { get; set; }

    public async Task OnGetAsync()
    {
        Product = (List<Domain.Entity.Product>?)await _unitOfWork.Products.GetAllAsync();
    }
}
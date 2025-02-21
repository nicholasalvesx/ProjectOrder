using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Product;
public class ProductModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductModel(IEnumerable<Domain.Entity.Product> products, IUnitOfWork unitOfWork)
    {
        Product = products;
        _unitOfWork = unitOfWork;
    }
    public IEnumerable<Domain.Entity.Product> Product { get; set; }
    public async Task OnGetAsync()
    {
        Product = await _unitOfWork.Products.GetAllAsync();
    }
}
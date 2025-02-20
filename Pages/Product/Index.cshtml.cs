using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Repository;

namespace ProjectOrder.Pages.Product;

public class ProductModel : PageModel
{
    private readonly IProductRepository _productRepository;
    public ProductModel(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public IEnumerable<Domain.Entity.Product>? Products { get; set; }
    public async Task OnGetAsync()
    {
        Products = await _productRepository.GetAllAsync();
    }
}
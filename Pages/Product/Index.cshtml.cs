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
    public List<Domain.Entity.Product>? Product { get; set; }
    public async Task OnGetAsync()
    {
        Product = (List<Domain.Entity.Product>?)await _productRepository.GetAllAsync();
    }
}
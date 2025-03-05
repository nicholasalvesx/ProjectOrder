using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Repository;

namespace ProjectOrder.Pages.Product;

public class ProductModel(IProductRepository productRepository) : PageModel
{
    public List<Domain.Entity.Product>? Product { get; set; }
    public async Task OnGetAsync()
    {
        Product = (List<Domain.Entity.Product>?)await productRepository.GetAllAsync();
    }
}
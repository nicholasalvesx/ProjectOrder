using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Infra.Data;

namespace ProjectOrder.Pages.Product;

public class ProductModel : PageModel
{
    private readonly AppDbContext _context;
    public List<Domain.Entity.Product> Products { get; set; } = new();
    
    public ProductModel(AppDbContext context)
    {
        _context = context;
    }
    public void OnGet()
    {
        Products = _context.Products.ToList();
    }
}
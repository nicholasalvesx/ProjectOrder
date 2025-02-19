using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Infra.Data;

namespace ProjectOrder.Pages.Product;

public class CreateProductModel : PageModel
{
    private readonly AppDbContext _context;

    [BindProperty]
    public Domain.Entity.Product Product { get; set; } = new();

    public CreateProductModel(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Products.Add(Product);
        _context.SaveChanges();
        return RedirectToPage("Index");
    }
}
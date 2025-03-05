using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Product;

public class EditProductModel(IUnitOfWork unitOfWork, IProductRepository productRepository)
    : PageModel
{
    [BindProperty] public Domain.Entity.Product? Product { get; set; } = new();
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Product = await productRepository.GetByIdAsync(id);
        
        if (Product == null)
        {
            return NotFound();
        }
        
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (Product == null)
        {
            return BadRequest();
        }

        var existingproduct = await productRepository.GetByIdAsync(Product.Id);

        if (existingproduct == null)
        {
            return NotFound();
        }

        existingproduct.Name = Product.Name;
        existingproduct.Price = Product.Price;

        productRepository.UpdateProduct(existingproduct);
        await unitOfWork.CommitAsync();
        return RedirectToPage("Index");
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Product;

public class DeleteProduct : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    [BindProperty] public Domain.Entity.Product? Product { get; set; }
    
    public DeleteProduct(IUnitOfWork unitOfWork, Domain.Entity.Product product)
    {
        _unitOfWork = unitOfWork;
        Product = product;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Product = await _unitOfWork.Products.GetByIdAsync(id);
        if (Product == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _unitOfWork.Products.AddProduct(Product);
        await _unitOfWork.CommitAsync();
        return RedirectToPage("./Index");
    }
}
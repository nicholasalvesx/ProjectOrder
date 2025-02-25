using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Product;

public class EditProductModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;

    public EditProductModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Domain.Entity.Product? Product { get; set; }
    public async Task<IActionResult> OnPostAsync(int id)
    {
        Product = await _unitOfWork.Products.GetByIdAsync(id);
        if (Product == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostEditAsync(int id)
    {
        if (!ModelState.IsValid)
            return Page();

        if (Product != null) await _unitOfWork.Products.UpdateProduct(Product);
        await _unitOfWork.CommitAsync();
        return RedirectToPage("Index");
    }
}
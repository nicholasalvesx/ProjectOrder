using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectOrder.Infra.Data;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Product;

public class CreateProductModel : PageModel
{
    public Domain.Entity.Product Product { get; set; }
    
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductModel(Domain.Entity.Product product, IUnitOfWork unitOfWork)
    {
        Product = product;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        await _unitOfWork.Products.AddProduct(Product);
        await _unitOfWork.CommitAsync();
        return RedirectToPage("Index");
    }
}
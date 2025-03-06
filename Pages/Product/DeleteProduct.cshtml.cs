using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Product;

public class DeleteProduct : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;
    public Domain.Entity.Product? Product { get; set; }
    public DeleteProduct(IUnitOfWork unitOfWork, IProductRepository productRepository)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }
    
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Product = await _productRepository.GetByIdAsync(id);
        if (Product == null)
        {
            return NotFound();
        }
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync(int id)
    {
        var deleteProduct = await _productRepository.GetByIdAsync(id);
        if (deleteProduct == null)
        {
            return NotFound();
        }
        
        _productRepository.DeleteProduct(deleteProduct);
        await _unitOfWork.CommitAsync();
        return RedirectToPage("./Index");
    }
}
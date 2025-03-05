using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Product;

public class CreateProductModel : PageModel
{
    [BindProperty]
    public Domain.Entity.Product Product { get; set; } = new();

    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;

    public CreateProductModel(IUnitOfWork unitOfWork, IProductRepository productRepository)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var product = new Domain.Entity.Product(Product.Name, Product.Price);
        
        _productRepository.AddProduct(product);
        await _unitOfWork.CommitAsync();
        return RedirectToPage("./Index");
    }
}
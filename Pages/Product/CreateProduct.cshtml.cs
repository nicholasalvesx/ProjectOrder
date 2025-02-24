using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Application.Commands;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Product;
public class CreateProductModel : PageModel
{
    [BindProperty] public CreateProductCommand ProductCommand { get; set; } = new();

    private readonly IUnitOfWork _unitOfWork;
    public CreateProductModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        var result = await ProductCommand.ExecutAsync(_unitOfWork);
        if (result)
        {
            return RedirectToPage("Index");
        }
        
        ModelState.AddModelError(string.Empty, "Invalid input");
        await _unitOfWork.CommitAsync();
        return Page();
    }
}
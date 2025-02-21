using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Application.Commands;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Customer;

public class CreateCustomerModel : PageModel
{
    [BindProperty] public CreateCustomerCommand CustomerCommand { get; set; } = new();
    
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        var result = await CustomerCommand.ExecuteAsync(_unitOfWork);
        if (result)
        {
            return RedirectToPage("Index");
        }
        ModelState.AddModelError(string.Empty, "Customer already exists");
        await _unitOfWork.CommitAsync();
        return Page();
    }
}
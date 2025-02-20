using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Customer;

public class CreateCustomerModel : PageModel
{
    [BindProperty] public Domain.Entity.Customer Customer { get; set; }
    
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerModel(Domain.Entity.Customer customer, IUnitOfWork unitOfWork)
    {
        Customer = customer;
        _unitOfWork = unitOfWork;
    }
    public async Task<IActionResult> OnPostAsync(Domain.Entity.Customer customer)
    {
        if (!ModelState.IsValid)
            return Page();
        
        await _unitOfWork.Customers.AddCustomer(customer);
        await _unitOfWork.CommitAsync();
        return RedirectToPage("Index");
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Repository;
using ProjectOrder.Domain.Entity;

namespace ProjectOrder.Pages.Customer;

public class CreateCustomerModel : PageModel
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerModel(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    [BindProperty]
    public Domain.Entity.Customer Customer { get; set; } = new();
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();
        
        await _customerRepository.AddCustomer(Customer);
        return RedirectToPage("Index");
    }
}
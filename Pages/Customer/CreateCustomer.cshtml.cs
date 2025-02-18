using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Repository;

namespace ProjectOrder.Pages.Customer;
public class CreateCustomerModel : PageModel
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerModel(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public Domain.Entity.Customer Customer { get; set; } = new();

    public Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Task.FromResult<IActionResult>(Page());
            
        _customerRepository.AddCustomer(Customer);
        return Task.FromResult<IActionResult>(RedirectToPage("Index"));
    }
}
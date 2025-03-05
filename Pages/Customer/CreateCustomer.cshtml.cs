using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Customer;

public class CreateCustomerModel : PageModel
{
    [BindProperty]
    public Domain.Entity.Customer Customer { get; set; } = new();
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerModel(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
    {
        _unitOfWork = unitOfWork;
        _customerRepository = customerRepository;
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
       
        var customer = new Domain.Entity.Customer(Customer.Name, Customer.Email);

        _customerRepository.AddCustomer(customer);
        await _unitOfWork.CommitAsync();
        return RedirectToPage("Index");
    }
}
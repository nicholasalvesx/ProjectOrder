using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Customer;
public class EditCustomerModel(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
    : PageModel
{
    [BindProperty] public Domain.Entity.Customer? Customer { get; set; } = new();
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Customer = await customerRepository.GetByIdAsync(id);
        if (Customer == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (Customer == null)
        {
            return BadRequest();
        }
        
        var existingcustomer = await customerRepository.GetByIdAsync(Customer.Id);

        if (existingcustomer == null)
        {
            return NotFound();
        }
        
        existingcustomer.Name = Customer.Name;
        existingcustomer.Email = Customer.Email;
        
        customerRepository.UpdateCustomer(existingcustomer);
        await unitOfWork.CommitAsync();
        return RedirectToPage("Index");
    }
}
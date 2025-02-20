using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Repository;

namespace ProjectOrder.Pages.Customer;

public class DeleteCustomerModel : PageModel
{
    private readonly ICustomerRepository _repository;

    public DeleteCustomerModel(ICustomerRepository repository, Domain.Entity.Customer customer)
    {
        _repository = repository;
        Customer = customer;
    }

    [BindProperty]
    public Domain.Entity.Customer Customer { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Customer = await _repository.GetByIdAsync(id);
        if (Customer == null)
            return NotFound();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _repository.DeleteCustomer(Customer);
        return RedirectToPage("Index");
    }
}
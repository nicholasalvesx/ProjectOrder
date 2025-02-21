using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Repository;

namespace ProjectOrder.Pages.Customer;

public class EditCustomerModel : PageModel
{
    private readonly ICustomerRepository _repository;
    public EditCustomerModel(ICustomerRepository repository, Domain.Entity.Customer customer)
    {
        _repository = repository;
        Customer = customer;
    }
    [BindProperty] public Domain.Entity.Customer? Customer { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Customer = await _repository.GetByIdAsync(id);
        if (Customer == null)
            return NotFound();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        Debug.Assert(Customer != null, nameof(Customer) + " != null");
        await _repository.UpdateCustomer(Customer);
        return RedirectToPage("Index");
    }
}
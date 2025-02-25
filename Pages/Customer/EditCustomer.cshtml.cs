using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Customer;

public class EditCustomerModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    public EditCustomerModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Domain.Entity.Customer? Customer { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Customer = await _unitOfWork.Customers.GetByIdAsync(id);
        if (Customer == null)
        {
            return NotFound();
        }
        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        if (Customer != null) await _unitOfWork.Customers.UpdateCustomer(Customer);
        await _unitOfWork.CommitAsync();
        return RedirectToPage("Index");
    }
}
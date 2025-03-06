using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Pages.Customer;

public class DeleteCustomerModel : PageModel
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteCustomerModel(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
    {
        _unitOfWork = unitOfWork;
        _customerRepository = customerRepository;
    }
    
    public Domain.Entity.Customer? Customer { get; set; }
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Customer = await _customerRepository.GetByIdAsync(id);
        if (Customer == null)
        {
            return NotFound();
        }   
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync(int id)
    {
        var deletecustomer = await _customerRepository.GetByIdAsync(id);
        if (deletecustomer == null)
        {
            return NotFound();
        }
        
        _customerRepository.DeleteCustomer(deletecustomer);
        await _unitOfWork.CommitAsync();
        return RedirectToPage("Index");
    }
}
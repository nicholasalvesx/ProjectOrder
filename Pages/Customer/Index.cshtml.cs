using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectOrder.Domain.Repository;

namespace ProjectOrder.Pages.Customer;

public class CustomerModel : PageModel
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerModel(ICustomerRepository customerRepository, IEnumerable<Domain.Entity.Customer> costumers)
    {
        _customerRepository = customerRepository;
        Costumers = costumers;
    }
    public IEnumerable<Domain.Entity.Customer> Costumers { get; set; }
    public async Task OnGetAsync()
    {
        Costumers = await _customerRepository.GetAllAsync();     
    }
}
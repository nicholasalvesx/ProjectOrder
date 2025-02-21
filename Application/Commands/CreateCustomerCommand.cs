using ProjectOrder.Domain.Entity;
using ProjectOrder.Infra.UnitOfWork;

namespace ProjectOrder.Application.Commands;
public class CreateCustomerCommand
{
    public string Name { get; set; }
    public string Email { get; set; }

    public async Task<bool> ExecuteAsync(IUnitOfWork unitOfWork)
    {
        var customer = new Customer(Name, Email);
        
        await unitOfWork.Customers.AddCustomer(customer);
        await unitOfWork.CommitAsync();
        
        return true;
    }
}
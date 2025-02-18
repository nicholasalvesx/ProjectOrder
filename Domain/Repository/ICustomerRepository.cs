using ProjectOrder.Domain.Entity;

namespace ProjectOrder.Domain.Repository;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(int id);
    Task<IEnumerable<Customer>> GetAllAsync();
    Task AddCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
    void DeleteCustomer(Customer customer);
}
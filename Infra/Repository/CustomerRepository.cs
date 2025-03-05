using Microsoft.EntityFrameworkCore;
using ProjectOrder.Domain.Entity;
using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.Data;

namespace ProjectOrder.Infra.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;
    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }
    public void AddCustomer(Customer customer)
    {
         _context.Customers.AddAsync(customer);    }
    public void UpdateCustomer(Customer customer)
    {
        _context.Customers.Update(customer);    }
    public void DeleteCustomer(Customer customer)
    {
        _context.Customers.Remove(customer);    }
}

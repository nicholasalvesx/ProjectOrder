using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.Data;

namespace ProjectOrder.Infra.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IOrderRepository Orders { get; }
    public IProductRepository Products { get; }
    public ICustomerRepository Customers { get; }
    public UnitOfWork(AppDbContext context, IOrderRepository orderRepository, IProductRepository productRepository, ICustomerRepository customers)
    {
        _context = context;
        Orders = orderRepository;
        Products = productRepository;
        Customers = customers;
    }
    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
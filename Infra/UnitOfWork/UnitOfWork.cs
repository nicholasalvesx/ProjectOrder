using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.Data;

namespace ProjectOrder.Infra.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IOrderRepository Orders { get; }
    public IProductRepository Products { get; }
    public UnitOfWork(AppDbContext context, IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _context = context;
        Orders = orderRepository;
        Products = productRepository;
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
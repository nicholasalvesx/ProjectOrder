using ProjectOrder.Domain.Repository;

namespace ProjectOrder.Infra.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    public IOrderRepository Orders { get; }
    public IProductRepository Products { get; }
    Task<int> CommitAsync();
}
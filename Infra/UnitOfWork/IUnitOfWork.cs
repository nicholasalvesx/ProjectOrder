namespace ProjectOrder.Infra.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
}
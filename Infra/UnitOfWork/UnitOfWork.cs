using ProjectOrder.Infra.Data;

namespace ProjectOrder.Infra.UnitOfWork;
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }
    public void Dispose()
    {
        context.Dispose();
    }
}
using Microsoft.EntityFrameworkCore;
using ProjectOrder.Domain.Entity;
using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.Data;

namespace ProjectOrder.Infra.Repository;

public class CostumerRepository : ICostumerRepository
{
    private readonly AppDbContext _context;

    public CostumerRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Costumer?> GetByIdAsync(int id)
    {
        return await _context.Costumers.FindAsync(id);
    }

    public async Task<IEnumerable<Costumer>> GetAllAsync()
    {
        return await _context.Costumers.ToListAsync();
    }

    public void AddCostumer(Costumer costumer)
    {
        _context.Costumers.Add(costumer);
    }

    public void UpdateCostumer(Costumer costumer)
    {
        _context.Costumers.Update(costumer);
    }

    public void DeleteCostumer(Costumer costumer)
    {
        _context.Costumers.Remove(costumer);
    }
}
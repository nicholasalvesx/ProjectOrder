using ProjectOrder.Domain.Entity;

namespace ProjectOrder.Domain.Repository;

public interface ICostumerRepository
{
    Task<Costumer?> GetByIdAsync(int id);
    Task<IEnumerable<Costumer>> GetAllAsync();
    void AddCostumer(Costumer costumer);
    void UpdateCostumer(Costumer costumer);
    void DeleteCostumer(Costumer costumer);
}
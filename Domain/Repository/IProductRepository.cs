using ProjectOrder.Domain.Entity;

namespace ProjectOrder.Domain.Repository;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int productId);
    Task<IEnumerable<Product>> GetAllAsync();
    Task AddProduct(Product product);
    Task UpdateProduct(Product product);
    Task DeleteProduct(Product product);
}
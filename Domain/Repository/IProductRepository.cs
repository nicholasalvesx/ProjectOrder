using ProjectOrder.Domain.Entity;

namespace ProjectOrder.Domain.Repository;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int productId);
    Task<IEnumerable<Product>> GetAllAsync();
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
}
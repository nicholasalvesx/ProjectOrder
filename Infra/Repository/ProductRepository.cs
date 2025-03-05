using Microsoft.EntityFrameworkCore;
using ProjectOrder.Domain.Entity;
using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.Data;

namespace ProjectOrder.Infra.Repository;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await context.Products.FindAsync(id);
    }
    public async Task<List<Product>> GetAllAsync()
    {
        return await context.Products.ToListAsync();
    }
    public void AddProduct(Product product)
    {
        context.Products.Add(product);
    }
    public void UpdateProduct(Product product)
    {
        context.Products.Update(product);

    }
    public void DeleteProduct(Product product)
    {
        context.Products.Remove(product);
    
    }
}
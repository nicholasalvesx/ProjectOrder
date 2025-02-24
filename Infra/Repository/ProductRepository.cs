using Microsoft.EntityFrameworkCore;
using ProjectOrder.Domain.Entity;
using ProjectOrder.Domain.Repository;
using ProjectOrder.Infra.Data;

namespace ProjectOrder.Infra.Repository;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<Product?> GetByIdAsync(int productId)
    {
        return await context.Products.FindAsync(productId);
    }
    public async Task<List<Product>> GetAllAsync()
    {
        return await context.Products.ToListAsync();
    }
    public async Task AddProduct(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
    }
    public async Task UpdateProduct(Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }
    public async Task DeleteProduct(Product product)
    {
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }
}
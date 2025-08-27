using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository
{
    Task AddProductAsync(Product product);
    Task<Product?> GetProductByIdAsync(string id);
    Task UpdateProductAsync(Product product);     
    Task DeleteProductAsync(string id);           
    Task<List<Product>> GetAllProductsAsync();
}
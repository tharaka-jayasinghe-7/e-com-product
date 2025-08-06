using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository
{
    Task AddProductAsync(Product product);
    Task<Product?> GetProductByIdAsync(string id);
}
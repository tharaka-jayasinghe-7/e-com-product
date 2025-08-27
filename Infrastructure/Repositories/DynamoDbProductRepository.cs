using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class DynamoDbProductRepository : IProductRepository
{
    private readonly DynamoDBContext _context;

    public DynamoDbProductRepository()
    {
        var client = new AmazonDynamoDBClient(); // Uses Lambda role or AWS credentials
        _context = new DynamoDBContext(client);
    }

    public async Task AddProductAsync(Product product)
    {
        await _context.SaveAsync(product);
    }

    public async Task<Product?> GetProductByIdAsync(string id)
    {
        return await _context.LoadAsync<Product>(id);
    }
    
    public async Task UpdateProductAsync(Product product)
    {
        await _context.SaveAsync(product); // SaveAsync updates if item exists
    }

    public async Task DeleteProductAsync(string id)
    {
        await _context.DeleteAsync<Product>(id);
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        var scanConditions = new List<ScanCondition>(); // no filters = get all
        return await _context.ScanAsync<Product>(scanConditions).GetRemainingAsync();
    }
}
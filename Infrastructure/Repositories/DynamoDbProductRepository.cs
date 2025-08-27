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
}
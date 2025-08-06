using Domain.Entities;
using Domain.Interfaces;
using Application.DTOs;

namespace Application.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task AddProductAsync(ProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price
        };

        await _repository.AddProductAsync(product);
    }

    public async Task<Product?> GetProductByIdAsync(string id)
    {
        return await _repository.GetProductByIdAsync(id);
    }
}
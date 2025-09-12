using Domain.Entities;
using Domain.Interfaces;
using Application.DTOs;

namespace Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        // ✅ Add new product
        public async Task AddProductAsync(ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                OriginalPrice = dto.OriginalPrice,
                ImageUrl = dto.ImageUrl,
                Category = dto.Category,
                Rating = dto.Rating,
                Reviews = dto.Reviews,
                IsNew = dto.IsNew,
                Sale = dto.Sale,
                Description = dto.Description,
                Features = dto.Features
            };

            await _repository.AddProductAsync(product);
        }

        // ✅ Get product by Id
        public async Task<Product?> GetProductByIdAsync(string id)
        {
            return await _repository.GetProductByIdAsync(id);
        }

        // ✅ Get all products
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _repository.GetAllProductsAsync();
        }

        // ✅ Update product
        public async Task<bool> UpdateProductAsync(string id, ProductDto dto)
        {
            var existing = await _repository.GetProductByIdAsync(id);
            if (existing == null)
                return false;

            existing.Name = dto.Name;
            existing.Price = dto.Price;
            existing.OriginalPrice = dto.OriginalPrice;
            existing.ImageUrl = dto.ImageUrl;
            existing.Category = dto.Category;
            existing.Rating = dto.Rating;
            existing.Reviews = dto.Reviews;
            existing.IsNew = dto.IsNew;
            existing.Sale = dto.Sale;
            existing.Description = dto.Description;
            existing.Features = dto.Features;

            await _repository.UpdateProductAsync(existing);
            return true;
        }

        // ✅ Delete product
        public async Task<bool> DeleteProductAsync(string id)
        {
            var existing = await _repository.GetProductByIdAsync(id);
            if (existing == null)
                return false;

            await _repository.DeleteProductAsync(id);
            return true;
        }
    }
}

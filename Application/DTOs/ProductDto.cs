namespace Application.DTOs;

public class ProductDto
{
    public string? Id { get; set; } 
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}
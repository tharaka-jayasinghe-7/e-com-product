namespace Application.DTOs
{
    public class ProductDto
    {
        public string? Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public decimal OriginalPrice { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string Category { get; set; } = null!;

        public double Rating { get; set; }

        public int Reviews { get; set; }

        public bool IsNew { get; set; }

        public bool Sale { get; set; }

        public string Description { get; set; } = null!;

        public List<string> Features { get; set; } = new();
    }
}
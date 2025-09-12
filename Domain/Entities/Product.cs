using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

namespace Domain.Entities
{
    [DynamoDBTable("Products")]
    public class Product
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [DynamoDBProperty]
        public string Name { get; set; } = null!;

        [DynamoDBProperty]
        public decimal Price { get; set; }

        [DynamoDBProperty]
        public decimal OriginalPrice { get; set; }

        // Store S3 image URL here
        [DynamoDBProperty]
        public string ImageUrl { get; set; } = null!;

        [DynamoDBProperty]
        public string Category { get; set; } = null!;

        [DynamoDBProperty]
        public double Rating { get; set; }

        [DynamoDBProperty]
        public int Reviews { get; set; }

        [DynamoDBProperty]
        public bool IsNew { get; set; }

        [DynamoDBProperty]
        public bool Sale { get; set; }

        [DynamoDBProperty]
        public string Description { get; set; } = null!;

        [DynamoDBProperty]
        public List<string> Features { get; set; } = new();
    }
}
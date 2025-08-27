using Amazon.DynamoDBv2.DataModel;

namespace Domain.Entities;

[DynamoDBTable("Products")]
public class Product
{
    [DynamoDBHashKey]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [DynamoDBProperty]
    public string Name { get; set; } = null!;

    [DynamoDBProperty]
    public decimal Price { get; set; }
}
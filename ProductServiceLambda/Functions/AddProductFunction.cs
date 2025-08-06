using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Application.DTOs;
using Application.Services;
using Infrastructure.Repositories;
using System.Text.Json;


namespace ProductServiceLambda.Functions;

public class AddProductFunction
{
    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        var dto = JsonSerializer.Deserialize<ProductDto>(request.Body!);
        var service = new ProductService(new DynamoDbProductRepository());

        await service.AddProductAsync(dto!);

        return new APIGatewayProxyResponse
        {
            StatusCode = 201,
            Body = "Product created"
        };
    }
}
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Application.Services;
using Infrastructure.Repositories;
using System.Text.Json;

namespace ProductServiceLambda.Functions;

public class GetProductFunction
{
    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        var productId = request.PathParameters["id"];
        var service = new ProductService(new DynamoDbProductRepository());

        var product = await service.GetProductByIdAsync(productId!);
        if (product == null)
        {
            return new APIGatewayProxyResponse { StatusCode = 404 };
        }

        return new APIGatewayProxyResponse
        {
            StatusCode = 200,
            Body = JsonSerializer.Serialize(product),
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
        };
    }
}
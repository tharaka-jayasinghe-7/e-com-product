using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Infrastructure.Repositories;
using Application.Services;
using System.Text.Json;

namespace ProductServiceLambda.Functions;

public class GetAllProductsFunction
{
    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        try
        {
            var service = new ProductService(new DynamoDbProductRepository());
            var products = await service.GetAllProductsAsync();

            return new APIGatewayProxyResponse
            {
                StatusCode = 200,
                Body = JsonSerializer.Serialize(products),
                Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
            };
        }
        catch (Exception ex)
        {
            context.Logger.LogError(ex, "Error in GetAllProductsFunction");
            return new APIGatewayProxyResponse
            {
                StatusCode = 500,
                Body = "Internal server error"
            };
        }
    }
}
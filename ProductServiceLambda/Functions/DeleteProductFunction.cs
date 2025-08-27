using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Infrastructure.Repositories;
using Application.Services;

namespace ProductServiceLambda.Functions;

public class DeleteProductFunction
{
    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        var id = request.PathParameters?["id"];
        if (string.IsNullOrEmpty(id))
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = 400,
                Body = "Product Id is required"
            };
        }

        var service = new ProductService(new DynamoDbProductRepository());
        var deleted = await service.DeleteProductAsync(id);

        if (!deleted)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = 404,
                Body = "Product not found"
            };
        }

        return new APIGatewayProxyResponse
        {
            StatusCode = 200,
            Body = "Product deleted"
        };
    }
}
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Infrastructure.Repositories;
using Application.Services;
using System.Text.Json;
using Application.DTOs;

namespace ProductServiceLambda.Functions;

public class UpdateProductFunction
{
    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        try
        {
            // Deserialize request body
            var dto = JsonSerializer.Deserialize<ProductDto>(request.Body!);
            
            if (dto == null || string.IsNullOrEmpty(dto.Id))
            {
                return new APIGatewayProxyResponse
                {
                    StatusCode = 400,
                    Body = "Product Id is required"
                };
            }

            // Call service to update product
            var service = new ProductService(new DynamoDbProductRepository());
            var updated = await service.UpdateProductAsync(dto.Id, dto);

            if (!updated)
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
                Body = "Product updated successfully"
            };
        }
        catch (Exception ex)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = 500,
                Body = $"Error: {ex.Message}"
            };
        }
    }
}
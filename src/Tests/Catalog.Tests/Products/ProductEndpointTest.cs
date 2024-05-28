using System.Net;
using System.Net.Http.Json;
using Catalog.Api.CatalogApis.ProductsApi;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Catalog.Tests.Products;

public class ProductEndpointsTests(CustomWebApplicationFactory<Program> factory)
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient(new WebApplicationFactoryClientOptions
    {
        AllowAutoRedirect = false
    });

    [Fact]
    public async Task CreateProduct_ReturnsCreatedProduct()
    {
        var request = new CreateOrderRequest(
            "Test Product",
            "Test Summary",
            "Test Description",
            "TestImage.jpg",
            "60d5ec49f8a53026e0b4d1a4",
            "60d5ec49f8a53026e0b4d1a5",
            99.99m
        );

        var response = await _client.PostAsJsonAsync("/product", request);

        response.EnsureSuccessStatusCode();

        var responseData = await response.Content.ReadFromJsonAsync<CreateOrderResponse>();

        Assert.NotNull(responseData);
        Assert.Equal("Test Product", responseData.Product.Name);
    }
    // Positive test case: Create product with minimum required fields
    [Fact]
    public async Task CreateProduct_WithMinimumFields_ReturnsCreatedProduct()
    {
        var request = new CreateOrderRequest(
            "Test Product",
            "Test Summary",
            "Test Description",
            "TestImage.jpg",
            "60d5ec49f8a53026e0b4d1a4", // Assume valid brand id
            "60d5ec49f8a53026e0b4d1a5", // Assume valid type id
            10.00m
        );

        var response = await _client.PostAsJsonAsync("/product", request);

        response.EnsureSuccessStatusCode();

        var responseData = await response.Content.ReadFromJsonAsync<CreateOrderResponse>();

        Assert.NotNull(responseData);
        Assert.Equal("Test Product", responseData.Product.Name);
    }

    // Negative test case: Missing required fields
    [Fact]
    public async Task CreateProduct_MissingRequiredFields_ReturnsBadRequest()
    {
        var request = new
        {
            // Name is missing
            Summary = "Test Summary",
            Description = "Test Description",
            ImageFile = "TestImage.jpg",
            BrandId = "60d5ec49f8a53026e0b4d1a4", // Assume valid brand id
            TypeId = "60d5ec49f8a53026e0b4d1a5", // Assume valid type id
            Price = 99.99m
        };

        var response = await _client.PostAsJsonAsync("/product", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    // Negative test case: Invalid price
    [Fact]
    public async Task CreateProduct_InvalidPrice_ReturnsBadRequest()
    {
        var request = new CreateOrderRequest(
            "Test Product",
            "Test Summary",
            "Test Description",
            "TestImage.jpg",
            "60d5ec49f8a53026e0b4d1a4", // Assume valid brand id
            "60d5ec49f8a53026e0b4d1a5", // Assume valid type id
            -10.00m // Invalid price
        );

        var response = await _client.PostAsJsonAsync("/product", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    // Negative test case: Nonexistent brand or type
    [Fact]
    public async Task CreateProduct_NonexistentBrandOrType_ReturnsBadRequest()
    {
        var request = new CreateOrderRequest(
            "Test Product",
            "Test Summary",
            "Test Description",
            "TestImage.jpg",
            "invalidBrandId", // Nonexistent brand id
            "invalidTypeId", // Nonexistent type id
            99.99m
        );

        var response = await _client.PostAsJsonAsync("/product", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}

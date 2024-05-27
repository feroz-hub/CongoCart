using System.Net.Http.Json;
using Catalog.Api.CatalogApis.ProductsApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Catalog.IntegrationTests.ProductsTest;

public class ProductEndpointsTests(CatalogWebApplicationFactory<Program> factory)
    : IClassFixture<CatalogWebApplicationFactory<Program>>
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
}
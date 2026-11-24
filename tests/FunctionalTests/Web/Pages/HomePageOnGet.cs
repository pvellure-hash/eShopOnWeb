using Microsoft.eShopWeb.FunctionalTests.Web;
using Xunit;

namespace Microsoft.eShopWeb.FunctionalTests.WebRazorPages;

[Collection("Sequential")]
public class HomePageOnGet : IClassFixture<TestApplication>
{
    public HomePageOnGet(TestApplication factory)
    {
        Client = factory.CreateClient();
    }

    public HttpClient Client { get; }

    [Fact]
    public async Task ReturnsHomePageWithProductListing()
    {
        // Arrange & Act
        var response = await Client.GetAsync("/");
        response.EnsureSuccessStatusCode();
        var stringResponse = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.Contains(".NET Bot Black Sweatshirt", stringResponse);
    }

    [Fact]
    public async Task ReturnsHealthEndpointThroughProgramEntryPoint()
    {
        // Arrange & Act
        var response = await Client.GetAsync("/health");
        var stringResponse = await response.Content.ReadAsStringAsync();

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Contains("\"status\"", stringResponse);
        Assert.Contains("\"Healthy\"", stringResponse);
    }
}

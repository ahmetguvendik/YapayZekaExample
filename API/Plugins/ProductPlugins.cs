using Microsoft.SemanticKernel;

namespace API.Plugins;

public class ProductPlugins
{
    private readonly HttpClient _httpClient;

    public ProductPlugins(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [KernelFunction("bestSellingProducts")]
    public async Task<string> BestSellingProducts()
    {
        var response = await _httpClient.GetAsync("http://localhost:5294/products");
        var result = await response.Content.ReadAsStringAsync();
        return result;
    }
}
using HttpAggregator.Models;
using HttpAggregator.Services.Interfaces;

namespace HttpAggregator.Services;

public class BranchService : IBranchService
{
    private readonly HttpClient _httpClient;

    public BranchService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<BranchModel> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/api/branches/{id}");
        return await response.Content.ReadFromJsonAsync<BranchModel>();
    }
}
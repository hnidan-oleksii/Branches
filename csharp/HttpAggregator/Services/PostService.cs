using HttpAggregator.Models;
using HttpAggregator.Services.Interfaces;

namespace HttpAggregator.Services;

public class PostService : IPostService
{
    private readonly HttpClient _httpClient;

    public PostService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<IEnumerable<PostModel>> GetByBranchId(int branchId)
    {
        var response = await _httpClient.GetAsync($"/api/branches/{branchId}/posts");
        return await response.Content.ReadFromJsonAsync<IEnumerable<PostModel>>();
    }
}
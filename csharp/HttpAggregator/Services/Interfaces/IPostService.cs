using HttpAggregator.Models;

namespace HttpAggregator.Services.Interfaces;

public interface IPostService
{
    Task<IEnumerable<PostModel>> GetByBranchId(int id);
}
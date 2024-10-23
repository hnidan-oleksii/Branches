using HttpAggregator.Models;

namespace HttpAggregator.Services.Interfaces;

public interface IBranchService
{
    Task<BranchModel> GetByIdAsync(int id);
}
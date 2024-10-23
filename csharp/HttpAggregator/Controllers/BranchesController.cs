using HttpAggregator.Models;
using HttpAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HttpAggregator.Controllers;

[ApiController]
[Route("api/[controller]/aggr")]
public class BranchesController : ControllerBase
{
    private readonly IBranchService _branchService;
    private readonly IPostService _postService;

    public BranchesController(IBranchService branchService, IPostService postService)
    {
        _branchService = branchService;
        _postService = postService;
    }

    [HttpGet("{branchId:int}")]
    [ProducesResponseType(typeof(BranchModel), StatusCodes.Status200OK)]
    public async Task<ActionResult<BranchModel>> GetBranches(int branchId)
    {
        var branch = await _branchService.GetByIdAsync(branchId);
        var posts = await _postService.GetByBranchId(branchId);
        branch.Posts = posts;

        return Ok(branch);
    }
}
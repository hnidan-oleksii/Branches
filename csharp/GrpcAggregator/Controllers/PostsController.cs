using GrpcAggregator.Models;
using GrpcAggregator.Services;
using Microsoft.AspNetCore.Mvc;

namespace GrpcAggregator.Controllers;

[ApiController]
[Route("api/[controller]/aggr")]
public class PostsController(PostsAggregatorService postsAggregatorService) : ControllerBase
{
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(PostModel), StatusCodes.Status200OK)]
    public async Task<ActionResult<PostModel>> GetPostAsync(int id)
    {
        var post = await postsAggregatorService.GetAggregatedPostAsync(id);
        return Ok(post);
    }
}

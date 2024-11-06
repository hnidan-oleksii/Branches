using Microsoft.AspNetCore.Mvc;
using PostsBLL.DTOs.Post;
using PostsBLL.DTOs.PostVote;
using PostsBLL.Helpers.Models;
using PostsBLL.Services.Interfaces;

namespace Posts.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;
    private readonly IPostVoteService _postVoteService;

    public PostsController(IPostService postService,
        IPostVoteService postVoteService)
    {
        _postService = postService;
        _postVoteService = postVoteService;
    }

    [HttpGet("{postId}", Name = "GetPostById")]
    [ProducesResponseType(typeof(PostDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPostById(int postId)
    {
        var post = await _postService.GetPostByIdAsync(postId);
        return Ok(post);
    }

    [HttpGet(Name = "GetPosts")]
    [ProducesResponseType(typeof(IEnumerable<PostDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPosts([FromQuery] PostParameters parameters)
    {
        var posts = await _postService.GetPosts(parameters);
        return Ok(posts);
    }

    [HttpGet("~/api/branches/{branchId}/posts", Name = "GetPostsByBranchId")]
    [ProducesResponseType(typeof(IEnumerable<PostDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPostsByCommunityId(int branchId)
    {
        var posts = await _postService.GetPostsByBranchIdAsync(branchId);
        return Ok(posts);
    }

    [HttpPost(Name = "CreatePost")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostDTO createPostDto)
    {
        var createdPost = await _postService.CreatePostAsync(createPostDto);
        return CreatedAtAction(nameof(GetPostById), new { postId = createdPost.Id }, createdPost);
    }

    [HttpPut("{id:int}", Name = "UpdatePost")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdatePost(int id,
        [FromBody] UpdatePostDTO updatePostDto)
    {
        await _postService.UpdatePostAsync(id, updatePostDto);
        return NoContent();
    }

    [HttpDelete("{id:int}", Name = "DeletePost")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeletePost(int id)
    {
        await _postService.DeletePostAsync(id);
        return NoContent();
    }

    [HttpPost("{postId}/upvote", Name = "UpvotePost")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpvotePost(int postId)
    {
        var dto = new CreatePostVoteDTO
        {
            PostId = postId,
            UserId = 1,
            VoteType = 1
        };
        await _postVoteService.VotePostAsync(dto);
        return Ok();
    }

    [HttpPost("{postId}/downvote", Name = "DownvotePost")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DownvotePost(int postId)
    {
        var dto = new CreatePostVoteDTO
        {
            PostId = postId,
            UserId = 1,
            VoteType = -1
        };
        await _postVoteService.VotePostAsync(dto);
        return Ok();
    }
}
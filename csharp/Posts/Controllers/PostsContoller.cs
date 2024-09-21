using Microsoft.AspNetCore.Mvc;
using PostsBLL.DTOs.Post;
using PostsBLL.DTOs.PostVote;
using PostsBLL.Helpers.Models;
using PostsBLL.Services.Interfaces;

namespace Posts.Controllers
{
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
        public async Task<IActionResult> GetPostById(int postId)
        {
            try
            {
                var post = await _postService.GetPostByIdAsync(postId);
                return Ok(post);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet(Name = "GetPosts")]
        public async Task<IActionResult> GetPosts([FromQuery] PostParameters parameters)
        {
            var posts = await _postService.GetPosts(parameters);
            return Ok(posts);
        }

        [HttpGet("~/api/branches/{branchId}/posts", Name = "GetPostsByBranchId")]
        public async Task<IActionResult> GetPostsByCommunityId(int branchId)
        {
            var posts = await _postService.GetPostsByBranchIdAsync(branchId);
            return Ok(posts);
        }

        [HttpPost(Name = "CreatePost")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDTO createPostDto)
        {
            var createdPost = await _postService.CreatePostAsync(createPostDto);
            return CreatedAtAction(nameof(GetPostById), new { postId = createdPost.Id }, createdPost);
        }

        [HttpPut("{id:int}", Name = "UpdatePost")]
        public async Task<IActionResult> UpdatePost(int id,
            [FromBody] UpdatePostDTO updatePostDto)
        {
            try
            {
                await _postService.UpdatePostAsync(id, updatePostDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}", Name = "DeletePost")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _postService.DeletePostAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("{postId}/upvote", Name = "UpvotePost")]
        public async Task<IActionResult> UpvotePost(int postId)
        {
            try
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
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("{postId}/downvote", Name = "DownvotePost")]
        public async Task<IActionResult> DownvotePost(int postId)
        {
            try
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
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
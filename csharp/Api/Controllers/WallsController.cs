using Application.Common.Models;
using Application.WallComments.Commands.CreateWallComment;
using Application.WallComments.Commands.DeleteWallComment;
using Application.WallComments.Commands.UpdateWallComment;
using Application.WallComments.Queries.GetCommentsByPostId;
using Application.WallPosts.Commands.CreateWallPost;
using Application.WallPosts.Commands.DeleteWallPost;
using Application.WallPosts.Commands.UpdateWallPost;
using Application.WallPosts.Queries.GetWallPostsByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/users/{userId}/wall")]
public class WallsController : ControllerBase
{
    private readonly IMediator _mediator;

    public WallsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // --- WallPost Endpoints ---

    [HttpGet]
    public async Task<ActionResult<List<WallPostDto>>> GetWallPostsByUserId(int userId)
    {
		var query = new GetWallPostsByUserIdQuery(userId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWallPost(int userId,
        [FromBody] CreateWallPostCommand command)
    {
        if (userId != command.ProfileUserId)
            return BadRequest("Comment ID in the route does not match the Comment ID in the body.");

        var postId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetWallPostsByUserId), new { userId });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWallPost(int id,
        [FromBody] UpdateWallPostCommand command)
    {
        if (id != command.PostId)
            return BadRequest("Post ID in the route does not match the Post ID in the body.");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWallPost(int id)
    {
        var command = new DeleteWallPostCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }

    // --- WallComment Endpoints ---

    [HttpGet("{postId}/comments")]
    public async Task<ActionResult<List<WallCommentDto>>> GetCommentsByPostId(int postId)
    {
		var query = new GetCommentsByPostIdQuery(postId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("{postId}/comment")]
    public async Task<IActionResult> CreateWallComment(int postId,
        [FromBody] CreateWallCommentCommand command)
    {
        if (postId != command.PostId)
            return BadRequest("Post ID in the route does not match the Post ID in the body.");

        var commentId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCommentsByPostId), new { postId = command.PostId }, commentId);
    }

    [HttpPut("comment/{id}")]
    public async Task<IActionResult> UpdateWallComment(int id,
        [FromBody] UpdateWallCommentCommand command)
    {
        if (id != command.CommentId)
            return BadRequest("Comment ID in the route does not match the Comment ID in the body.");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("comment/{id}")]
    public async Task<IActionResult> DeleteWallComment(int id)
    {
        var command = new DeleteWallCommentCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}

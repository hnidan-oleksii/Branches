using MediatR;

namespace Application.WallPosts.Commands.DeleteWallPost;

public record DeleteWallPostCommand : IRequest, IRequest<Unit>
{
    public int PostId { get; }
    
    public DeleteWallPostCommand(int postId)
    {
        PostId = postId;
    } 
}

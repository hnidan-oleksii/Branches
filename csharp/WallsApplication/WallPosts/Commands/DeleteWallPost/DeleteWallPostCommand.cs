using MediatR;

namespace WallsApplication.WallPosts.Commands.DeleteWallPost;

public record DeleteWallPostCommand : IRequest<Unit>
{
    public int PostId { get; }
    
    public DeleteWallPostCommand(int postId)
    {
        PostId = postId;
    } 
}

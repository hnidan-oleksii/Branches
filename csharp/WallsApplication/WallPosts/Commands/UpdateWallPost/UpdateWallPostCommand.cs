using MediatR;

namespace WallsApplication.WallPosts.Commands.UpdateWallPost;

public record UpdateWallPostCommand : IRequest, IRequest<Unit>
{
    public int PostId { get; }
    public string NewContent { get; }
}

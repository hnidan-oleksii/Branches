using MediatR;

namespace Application.WallPosts.Commands.CreateWallPost;

public record CreateWallPostCommand : IRequest<int>
{
    public int AuthorUserId { get; }
    public int ProfileUserId { get; }
    public string Content { get; }
}

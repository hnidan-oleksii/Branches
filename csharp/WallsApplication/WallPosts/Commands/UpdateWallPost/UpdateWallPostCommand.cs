using MediatR;

namespace WallsApplication.WallPosts.Commands.UpdateWallPost;

public record UpdateWallPostCommand : IRequest<Unit>
{
    public int Id { get; }
    public string Content { get; }

    public UpdateWallPostCommand(int id, string content)
    {
        Id = id;
        Content = content;
    }
}

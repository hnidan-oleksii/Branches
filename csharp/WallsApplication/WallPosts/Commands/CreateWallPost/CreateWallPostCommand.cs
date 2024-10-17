using MediatR;

namespace WallsApplication.WallPosts.Commands.CreateWallPost;

public record CreateWallPostCommand : IRequest<int>
{
    public int AuthorUserId { get; }
    public int ProfileUserId { get; }
    public string Content { get; }

    public CreateWallPostCommand(int authorUserId, int profileUserId, string content)
    {
        AuthorUserId = authorUserId;
        ProfileUserId = profileUserId;
        Content = content;
    }
}

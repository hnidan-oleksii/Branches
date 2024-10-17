using MediatR;

namespace WallsApplication.WallComments.Commands.CreateWallComment;

public record CreateWallCommentCommand : IRequest<int>
{
    public int PostId { get; }
    public int AuthorUserId { get; }
    public string Content { get; }

    public CreateWallCommentCommand(int postId, int authorUserId, string content)
    {
        PostId = postId;
        AuthorUserId = authorUserId;
        Content = content;
    }
}
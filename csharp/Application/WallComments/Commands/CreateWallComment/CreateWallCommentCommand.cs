using MediatR;

namespace Application.WallComments.Commands.CreateWallComment;

public record CreateWallCommentCommand : IRequest<int>
{
    public int PostId { get; }
    public int AuthorUserId { get; }
    public string Content { get; }
}
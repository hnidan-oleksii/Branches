using MediatR;

namespace Application.WallComments.Commands.UpdateWallComment;

public record UpdateWallCommentCommand : IRequest, IRequest<Unit>
{
    public int CommentId { get; }
    public string NewContent { get; }
}

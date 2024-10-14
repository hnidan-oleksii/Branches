using MediatR;

namespace WallsApplication.WallComments.Commands.UpdateWallComment;

public record UpdateWallCommentCommand : IRequest, IRequest<Unit>
{
    public int CommentId { get; }
    public string NewContent { get; }
}

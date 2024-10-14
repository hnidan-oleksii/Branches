using MediatR;

namespace WallsApplication.WallComments.Commands.DeleteWallComment;

public record DeleteWallCommentCommand : IRequest, IRequest<Unit>
{
    public int CommentId { get; }

    public DeleteWallCommentCommand(int commentId)
    {
        CommentId = commentId;
    }
}
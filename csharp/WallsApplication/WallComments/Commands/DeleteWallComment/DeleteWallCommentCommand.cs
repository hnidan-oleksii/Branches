using MediatR;

namespace WallsApplication.WallComments.Commands.DeleteWallComment;

public record DeleteWallCommentCommand : IRequest<Unit>
{
    public int Id { get; }

    public DeleteWallCommentCommand(int id)
    {
        Id = id;
    }
}
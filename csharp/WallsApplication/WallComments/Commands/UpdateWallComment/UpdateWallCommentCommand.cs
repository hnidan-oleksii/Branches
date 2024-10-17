using MediatR;

namespace WallsApplication.WallComments.Commands.UpdateWallComment;

public record UpdateWallCommentCommand : IRequest, IRequest<Unit>
{
    public int Id { get; }
    public string Content { get; }

    public UpdateWallCommentCommand(int id, string content)
    {
        Id = id;
        Content = content;
    }
}

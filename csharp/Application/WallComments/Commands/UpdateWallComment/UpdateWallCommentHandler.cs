using Application.Common.Interfaces;
using MediatR;

namespace Application.WallComments.Commands.UpdateWallComment;

public class UpdateWallCommentCommandHandler : IRequestHandler<UpdateWallCommentCommand, Unit>
{
    private readonly IWallContext _context;

    public UpdateWallCommentCommandHandler(IWallContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateWallCommentCommand request, CancellationToken cancellationToken)
    {
        var wallComment = await _context.WallComments.FindAsync(request.CommentId);

        if (wallComment == null)
            throw new KeyNotFoundException($"Comment with id: {request.CommentId} not found");

        wallComment.UpdateContent(request.NewContent);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

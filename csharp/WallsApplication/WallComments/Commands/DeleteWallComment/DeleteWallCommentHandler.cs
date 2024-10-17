using MediatR;
using WallsApplication.Common.Interfaces;

namespace WallsApplication.WallComments.Commands.DeleteWallComment;

public class DeleteWallCommentCommandHandler : IRequestHandler<DeleteWallCommentCommand, Unit>
{
    private readonly IWallContext _context;

    public DeleteWallCommentCommandHandler(IWallContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteWallCommentCommand request, CancellationToken cancellationToken)
    {
        var wallComment = await _context.WallComments.FindAsync(request.Id);

        if (wallComment == null)
            throw new KeyNotFoundException($"Comment with id: {request.Id} not found");

        _context.WallComments.Remove(wallComment);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

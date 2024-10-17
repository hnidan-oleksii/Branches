using MediatR;
using WallsApplication.Common.Interfaces;

namespace WallsApplication.WallComments.Commands.UpdateWallComment;

public class UpdateWallCommentCommandHandler : IRequestHandler<UpdateWallCommentCommand, Unit>
{
    private readonly IWallContext _context;

    public UpdateWallCommentCommandHandler(IWallContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateWallCommentCommand request, CancellationToken cancellationToken)
    {
        var wallComment = await _context.WallComments.FindAsync(request.Id);

        if (wallComment == null)
            throw new KeyNotFoundException($"Comment with id: {request.Id} not found");

        wallComment.UpdateContent(request.Content);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

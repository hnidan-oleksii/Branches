using MediatR;
using WallsApplication.Common.Interfaces;

namespace WallsApplication.WallPosts.Commands.DeleteWallPost;

public class DeleteWallPostCommandHandler : IRequestHandler<DeleteWallPostCommand, Unit>
{
    private readonly IWallContext _context;

    public DeleteWallPostCommandHandler(IWallContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteWallPostCommand request, CancellationToken cancellationToken)
    {
        var wallPost = await _context.WallPosts.FindAsync(request.PostId);

        if (wallPost == null)
            throw new KeyNotFoundException($"Wall post with id {request.PostId} was not found");

        _context.WallPosts.Remove(wallPost);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

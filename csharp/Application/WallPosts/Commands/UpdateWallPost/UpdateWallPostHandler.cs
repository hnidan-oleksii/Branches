using Application.Common.Interfaces;
using MediatR;

namespace Application.WallPosts.Commands.UpdateWallPost;

public class UpdateWallPostCommandHandler : IRequestHandler<UpdateWallPostCommand, Unit>
{
    private readonly IWallContext _context;

    public UpdateWallPostCommandHandler(IWallContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateWallPostCommand request, CancellationToken cancellationToken)
    {
        var wallPost = await _context.WallPosts.FindAsync(request.PostId);

        if (wallPost == null)
            throw new KeyNotFoundException($"Wall post with id {request.PostId} was not found");

        wallPost.UpdateContent(request.NewContent);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

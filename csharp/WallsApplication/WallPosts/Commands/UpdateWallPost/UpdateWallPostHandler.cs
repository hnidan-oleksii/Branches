using MediatR;
using WallsApplication.Common.Interfaces;

namespace WallsApplication.WallPosts.Commands.UpdateWallPost;

public class UpdateWallPostCommandHandler : IRequestHandler<UpdateWallPostCommand, Unit>
{
    private readonly IWallContext _context;

    public UpdateWallPostCommandHandler(IWallContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateWallPostCommand request, CancellationToken cancellationToken)
    {
        var wallPost = await _context.WallPosts.FindAsync(request.Id);

        if (wallPost == null)
            throw new KeyNotFoundException($"Wall post with id {request.Id} was not found");

        wallPost.UpdateContent(request.Content);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

using MediatR;
using Microsoft.Extensions.Caching.Memory;
using WallsApplication.Common.Interfaces;

namespace WallsApplication.WallComments.Commands.UpdateWallComment;

public class UpdateWallCommentCommandHandler(IWallContext context, IMemoryCache cache)
    : IRequestHandler<UpdateWallCommentCommand, Unit>
{
    public async Task<Unit> Handle(UpdateWallCommentCommand request, CancellationToken cancellationToken)
    {
        var wallComment = await context.WallComments.FindAsync(request.Id);

        if (wallComment == null)
            throw new KeyNotFoundException($"Comment with id: {request.Id} not found");

        wallComment.UpdateContent(request.Content);
        await context.SaveChangesAsync(cancellationToken);

        var cacheKey = $"wallCommentsByPostId:{wallComment.PostId}";
        cache.Remove(cacheKey);

        return Unit.Value;
    }
}
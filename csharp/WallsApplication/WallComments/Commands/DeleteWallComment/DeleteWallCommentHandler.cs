using MediatR;
using Microsoft.Extensions.Caching.Memory;
using WallsApplication.Common.Interfaces;

namespace WallsApplication.WallComments.Commands.DeleteWallComment;

public class DeleteWallCommentCommandHandler(IWallContext context, IMemoryCache cache)
    : IRequestHandler<DeleteWallCommentCommand, Unit>
{
    public async Task<Unit> Handle(DeleteWallCommentCommand request, CancellationToken cancellationToken)
    {
        var wallComment = await context.WallComments.FindAsync(request.Id);

        if (wallComment == null)
            throw new KeyNotFoundException($"Comment with id: {request.Id} not found");

        context.WallComments.Remove(wallComment);
        await context.SaveChangesAsync(cancellationToken);

        var cacheKey = $"wallCommentsByPostId:{wallComment.PostId}";
        cache.Remove(cacheKey);

        return Unit.Value;
    }
}
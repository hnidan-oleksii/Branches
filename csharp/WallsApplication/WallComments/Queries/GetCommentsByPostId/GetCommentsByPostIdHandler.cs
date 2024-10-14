using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WallsApplication.Common.Interfaces;
using WallsApplication.Common.Models;

namespace WallsApplication.WallComments.Queries.GetCommentsByPostId;

public class GetCommentsByPostIdQueryHandler : IRequestHandler<GetCommentsByPostIdQuery, List<WallCommentDto>>
{
    private readonly IWallContext _context;
    private readonly IMapper _mapper;

    public GetCommentsByPostIdQueryHandler(IWallContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<WallCommentDto>> Handle(GetCommentsByPostIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _context.WallPosts.FindAsync(request.PostId);
        if (post == null)
        {
            throw new KeyNotFoundException($"Post {request.PostId} not found");
        }

        var comments = await _context.WallComments
            .Where(c => c.PostId == request.PostId)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<WallCommentDto>>(comments);
    }
}

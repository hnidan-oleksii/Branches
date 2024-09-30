using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.WallPosts.Queries.GetWallPostsByUserId;

public class GetWallPostsByUserIdQueryHandler : IRequestHandler<GetWallPostsByUserIdQuery, List<WallPostDto>>
{
    private readonly IWallContext _context;
    private readonly IMapper _mapper;

    public GetWallPostsByUserIdQueryHandler(IWallContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<WallPostDto>> Handle(GetWallPostsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.UserId);
        if (user == null)
        {
            throw new KeyNotFoundException($"User with id {request.UserId} not found");
        }

        var posts = await _context.WallPosts
            .Where(p => p.ProfileUserId == request.UserId)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<WallPostDto>>(posts);
    }
}

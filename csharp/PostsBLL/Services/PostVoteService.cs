using AutoMapper;
using PostsBLL.DTOs.PostVote;
using PostsBLL.Services.Interfaces;
using PostsDAL_EF.Entities;
using PostsDAL_EF.UoW;

namespace PostsBLL.Services;

public class PostVoteService : IPostVoteService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PostVoteService(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task VotePostAsync(CreatePostVoteDTO dto)
    {
        await _unitOfWork.BeginTransactionAsync();

        var existingVote = await _unitOfWork.PostVotes.GetUserVoteAsync(postId: dto.PostId, userId: dto.UserId);

        if (existingVote == null)
        {
            var newVote = _mapper.Map<PostVote>(dto);
            newVote.VotedAt = DateTime.UtcNow;

            await _unitOfWork.PostVotes.AddAsync(newVote);
        }
        else if (existingVote.VoteType != dto.VoteType)
        {
            existingVote.VoteType = dto.VoteType;
            await _unitOfWork.PostVotes.UpdateAsync(existingVote);
        }
        else if (existingVote.VoteType == dto.VoteType)
        {
            await _unitOfWork.PostVotes.DeleteAsync(existingVote.PostId);
        }

        await _unitOfWork.SaveChangesAsync();
        await _unitOfWork.CommitTransactionAsync();
    }

    public async Task<int> GetPostVoteCountAsync(int postId)
    {
        return await _unitOfWork.PostVotes.GetVoteCountAsync(postId);
    }
}

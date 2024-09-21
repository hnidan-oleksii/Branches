using PostsBLL.DTOs.PostVote;

namespace PostsBLL.Services.Interfaces;

public interface IPostVoteService
{
    Task VotePostAsync(CreatePostVoteDTO dto);
    // Task UpvotePostAsync(int postId, int userId);
    // Task DownvotePostAsync(int postId, int userId);
    Task<int> GetPostVoteCountAsync(int postId);
}

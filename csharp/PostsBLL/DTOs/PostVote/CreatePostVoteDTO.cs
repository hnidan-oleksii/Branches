namespace PostsBLL.DTOs.PostVote;

public class CreatePostVoteDTO
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public short VoteType { get; set; }  // 1 for upvote, -1 for downvote
}

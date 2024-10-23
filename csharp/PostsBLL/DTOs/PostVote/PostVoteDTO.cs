namespace PostsBLL.DTOs.PostVote;

public class PostVoteDTO
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
    public short VoteType { get; set; }  // 1 for upvote, -1 for downvote
    public DateTime VotedAt { get; set; }
}

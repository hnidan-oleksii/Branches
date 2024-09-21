namespace PostsDAL_EF.Entities;

public class PostVote
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
    public short VoteType { get; set; }
    public DateTime VotedAt { get; set; }

    public User User { get; set; }
    public Post Post { get; set; }
}
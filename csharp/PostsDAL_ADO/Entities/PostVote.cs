namespace PostsDAL_ADO.Entities;

public class PostVote
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
    public short VoteType { get; set; }
    public DateTime VotedAt { get; set; }
}

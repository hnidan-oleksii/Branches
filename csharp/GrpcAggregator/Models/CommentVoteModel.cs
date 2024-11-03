namespace GrpcAggregator.Models;

public class CommentVoteModel
{
    public int Id { get; set; }
    public int CommentId { get; set; }
    public int UserId { get; set; }
    public int VoteType { get; set; }
}
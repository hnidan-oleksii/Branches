namespace GrpcAggregator.Models;

public class PostVoteModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int VoteType { get; set; }
}
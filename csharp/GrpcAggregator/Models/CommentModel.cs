namespace GrpcAggregator.Models;

public class CommentModel
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public List<CommentVoteModel> Votes { get; set; }
}
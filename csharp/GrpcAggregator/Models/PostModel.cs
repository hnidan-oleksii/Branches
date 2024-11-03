namespace GrpcAggregator.Models;

public class PostModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    public List<PostVoteModel> Votes { get; set; }
    public List<CommentModel> Comments { get; set; }
}
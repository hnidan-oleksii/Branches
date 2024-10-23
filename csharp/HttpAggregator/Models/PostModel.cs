namespace HttpAggregator.Models;

public class PostModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int BranchId { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public IEnumerable<PostVoteModel> Votes { get; set; }
}
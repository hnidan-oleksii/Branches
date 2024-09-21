namespace PostsDAL_EF.Entities;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int BranchId { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; } 
    public Branch Branch { get; set; } 
    public ICollection<PostVote> Votes { get; set; } = new List<PostVote>();
}
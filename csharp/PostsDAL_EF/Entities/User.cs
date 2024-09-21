namespace PostsDAL_EF.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<PostVote> PostVotes { get; set; } = new List<PostVote>();
}
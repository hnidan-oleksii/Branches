namespace PostsDAL_EF.Entities;

public class Branch
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Post> Posts { get; set; } = new List<Post>();
}
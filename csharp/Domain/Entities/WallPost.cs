namespace Domain.Entities;

public class WallPost
{
    public int Id { get; private set; }
    public int AuthorUserId { get; private set; }
    public int ProfileUserId { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }

    public ICollection<WallComment> Comments { get; private set; }

    public void UpdateContent(string newContent)
    {
        Content = newContent;
        UpdatedAt = DateTime.UtcNow;
    }
}

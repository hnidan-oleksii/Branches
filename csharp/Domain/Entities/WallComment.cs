namespace Domain.Entities;

public class WallComment
{
    public int Id { get; private set; }
    public int PostId { get; private set; }
    public int AuthorUserId { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }

    public void UpdateContent(string newContent)
    {
        Content = newContent;
        UpdatedAt = DateTime.UtcNow;
    }
}


namespace Application.Common.Models;

public class WallPostDto
{
    public int Id { get; set; }
    public int AuthorUserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public WallPostDto(int id, int authorUserId, string content, DateTime createdAt)
    {
        Id = id;
        AuthorUserId = authorUserId;
        Content = content;
        CreatedAt = createdAt;
    }
}

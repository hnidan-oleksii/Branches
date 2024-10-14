namespace WallsApplication.Common.Models;

public class WallCommentDto
{
    public int Id { get; set; }
    public int AuthorUserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}

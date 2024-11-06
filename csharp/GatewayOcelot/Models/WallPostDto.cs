namespace GatewayOcelot.Models;

public class WallPostDto
{
    public int Id { get; set; }
    public int AuthorUserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<WallCommentDto> WallComments { get; set; }
}
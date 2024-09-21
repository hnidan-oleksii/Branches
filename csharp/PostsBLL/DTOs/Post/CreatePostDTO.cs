namespace PostsBLL.DTOs.Post;

public class CreatePostDTO
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int BranchId { get; set; }
    public int UserId { get; set; }
}

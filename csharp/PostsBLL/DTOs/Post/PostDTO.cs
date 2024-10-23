using PostsBLL.DTOs.PostVote;

namespace PostsBLL.DTOs.Post;

public class PostDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int BranchId { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    public IEnumerable<PostVoteDTO> Votes { get; set; }
}
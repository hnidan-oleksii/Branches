namespace Branches_BLL.DTOs.BranchMember;

public class BranchMemberDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Role { get; set; }
    public DateTime JoinedAt { get; set; }
}
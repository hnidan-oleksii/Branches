namespace Branches_DAL.Entities;

public class BranchMember
{
    public int Id { get; set; }
    public int BranchId { get; set; }
    public int UserId { get; set; }
    public string Role { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    public Branch Branch { get; set; }
    public User User { get; set; }
}
namespace HttpAggregator.Models;

public class BranchModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public IEnumerable<PostModel> Posts { get; set; }
}
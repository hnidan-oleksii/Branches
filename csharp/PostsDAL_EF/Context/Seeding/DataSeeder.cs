using Bogus;
using PostsDAL_EF.Entities;

namespace PostsDAL_EF.Context.Seeding;

public class DataSeeder
{
    public IReadOnlyCollection<User> Users { get; }
    public IReadOnlyCollection<Branch> Branches { get; }
    public IReadOnlyCollection<Post> Posts { get; }
    public IReadOnlyCollection<PostVote> PostVotes { get; }

    public DataSeeder(int rows = 30)
    {
        Users = GenerateUsers(rows);
        Branches = GenerateBranches(rows);
        Posts = GeneratePosts(rows);
        PostVotes = GeneratePostVotes(rows);
    }

    private IReadOnlyCollection<User> GenerateUsers(int count)
    {
        var faker = new Faker<User>()
            .RuleFor(u => u.Id, f => f.IndexFaker + 1)
            .RuleFor(u => u.Name, f => f.Name.FullName());

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<Branch> GenerateBranches(int count)
    {
        var faker = new Faker<Branch>()
            .RuleFor(b => b.Id, f => f.IndexFaker + 1)
            .RuleFor(b => b.Name, f => f.Company.CompanyName());

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<Post> GeneratePosts(int count)
    {
        var faker = new Faker<Post>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.Title, f => f.Lorem.Sentence())
            .RuleFor(p => p.Content, f => f.Lorem.Paragraph())
            .RuleFor(p => p.BranchId, f => f.PickRandom<Branch>(Branches).Id)
            .RuleFor(p => p.UserId, f => f.PickRandom<User>(Users).Id)
            .RuleFor(p => p.CreatedAt, f => f.Date.Past().ToUniversalTime());

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<PostVote> GeneratePostVotes(int count)
    {
        var faker = new Faker<PostVote>()
            .RuleFor(pv => pv.Id, f => f.IndexFaker + 1)
            .RuleFor(pv => pv.PostId, f => f.PickRandom<Post>(Posts).Id)
            .RuleFor(pv => pv.UserId, f => f.PickRandom<User>(Users).Id)
            .RuleFor(pv => pv.VoteType, f => f.Random.Bool() ? (short)1 : (short)-1)
            .RuleFor(pv => pv.VotedAt, f => f.Date.Recent().ToUniversalTime());

        return GenerateRows(faker, count);
    }

    private IReadOnlyCollection<T> GenerateRows<T>(Faker<T> faker, int count) where T : class
    {
        return faker.Generate(count);
    }
}

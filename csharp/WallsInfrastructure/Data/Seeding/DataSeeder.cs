using Bogus;
using WallsDomain.Entities;

namespace WallsInfrastructure.Data.Seeding
{
    public class DataSeeder
    {
        public IReadOnlyCollection<User> Users { get; }
        public IReadOnlyCollection<WallPost> WallPosts { get; }
        public IReadOnlyCollection<WallComment> WallComments { get; }

        public DataSeeder(int rows = 30)
        {
            Users = GenerateUsers(rows);
            WallPosts = GenerateWallPosts(rows);
            WallComments = GenerateWallComments(rows);
        }

        private IReadOnlyCollection<User> GenerateUsers(int count)
        {
            var faker = new Faker<User>()
                .RuleFor(u => u.Id, f => f.IndexFaker + 1)
                .RuleFor(u => u.Name, f => f.Name.FullName());

            return GenerateRows(faker, count);
        }

        private IReadOnlyCollection<WallPost> GenerateWallPosts(int count)
        {
            var faker = new Faker<WallPost>()
                .RuleFor(wp => wp.Id, f => f.IndexFaker + 1)
                .RuleFor(wp => wp.AuthorUserId, f => f.PickRandom<User>(Users).Id)
                .RuleFor(wp => wp.ProfileUserId, f => f.PickRandom<User>(Users).Id)
                .RuleFor(wp => wp.Content, f => f.Lorem.Paragraph())
                .RuleFor(wp => wp.CreatedAt, f => f.Date.Past().ToUniversalTime())
                .RuleFor(wp => wp.UpdatedAt, f => f.Random.Bool() ? f.Date.Recent().ToUniversalTime() : (DateTime?)null)
                .RuleFor(wp => wp.Comments, (f, wp) => new List<WallComment>());

            return GenerateRows(faker, count);
        }

        private IReadOnlyCollection<WallComment> GenerateWallComments(int count)
        {
            var faker = new Faker<WallComment>()
                .RuleFor(wc => wc.Id, f => f.IndexFaker + 1)
                .RuleFor(wc => wc.AuthorUserId, f => f.PickRandom<User>(Users).Id)
                .RuleFor(wc => wc.PostId, f => f.PickRandom<WallPost>(WallPosts).Id)
                .RuleFor(wc => wc.Content, f => f.Lorem.Sentence())
                .RuleFor(wc => wc.CreatedAt, f => f.Date.Past().ToUniversalTime());

            return GenerateRows(faker, count);
        }

        private IReadOnlyCollection<T> GenerateRows<T>(Faker<T> faker, int count) where T : class
        {
            return faker.Generate(count);
        }
    }
}


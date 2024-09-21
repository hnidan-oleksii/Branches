using System.Data;
using Npgsql;
using PostsDAL_ADO.Entities;
using PostsDAL_ADO.Repositories.Interfaces;

namespace PostsDAL_ADO.Repositories;

public class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(NpgsqlConnection dbConnection, IDbTransaction dbTransaction) : base(dbConnection, dbTransaction)
    {
    }

    public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId)
    {
        var posts = new List<Post>();
        var query = "SELECT * FROM Posts WHERE UserId = @UserId";

        await using var command = _dbConnection.CreateCommand();
        command.CommandText = query;
        await _dbConnection.OpenAsync();
        
        var userIdParam = new NpgsqlParameter("@UserId", userId);
        command.Parameters.Add(userIdParam);
        
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            posts.Add(new Post
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Content = reader.GetString(2),
                BranchId = reader.GetInt32(3),
                UserId = reader.GetInt32(4),
                CreatedAt = reader.GetDateTime(5)
            });
        }
        return posts;
    }

    public async Task<IEnumerable<Post>> GetPostsByBranchIdAsync(int branchId)
    {
        var posts = new List<Post>();
        var query = "SELECT * FROM Posts WHERE BranchId = @BranchId";

        await using var command = _dbConnection.CreateCommand();
        command.CommandText = query;
        await _dbConnection.OpenAsync();
        
        var userIdParam = new NpgsqlParameter("@BranchId", branchId);
        command.Parameters.Add(userIdParam);
        
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            posts.Add(new Post
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Content = reader.GetString(2),
                BranchId = reader.GetInt32(3),
                UserId = reader.GetInt32(4),
                CreatedAt = reader.GetDateTime(5)
            });
        }
        return posts;
    }
}
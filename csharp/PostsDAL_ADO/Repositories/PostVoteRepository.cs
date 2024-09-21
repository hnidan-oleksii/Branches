using System.Data;
using System.Data.Common;
using Dapper;
using Npgsql;
using PostsDAL_ADO.Entities;
using PostsDAL_ADO.Repositories.Interfaces;

namespace PostsDAL_ADO.Repositories;

public class PostVoteRepository : Repository<PostVote>, IPostVoteRepository
{
    public PostVoteRepository(NpgsqlConnection dbConnection, IDbTransaction dbTransaction) : base(dbConnection, dbTransaction)
    {
    }

    public async Task<int> GetVoteCountAsync(int postId)
    {
        var query = "SELECT SUM(VoteType) FROM Post_Votes WHERE Id = @Id";
        return await _dbConnection.ExecuteScalarAsync<int>(query, new { Id = postId });
    }

    public async Task<PostVote?> GetUserVoteAsync(int postId, int userId)
    {
        var query = "SELECT * FROM Post_Votes WHERE Id = @Id AND UserId = @UserId";
        return await _dbConnection.QuerySingleOrDefaultAsync<PostVote>(query, new { Id = postId, UserId = userId });
    }
}
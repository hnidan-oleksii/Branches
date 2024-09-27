using System.Data;
using Branches_DAL.Entities;
using Branches_DAL.Repositories.Interfaces;
using Dapper;
using Npgsql;

namespace Branches_DAL.Repositories;

public class BranchRepository : Repository<Branch>, IBranchRepository
{
    public BranchRepository(NpgsqlConnection dbConnection, IDbTransaction dbTransaction) : base(dbConnection, dbTransaction, "branches")
    {
    }

    public async Task<IEnumerable<Branch>> GetBranchesWithModeratorsAsync()
    {
        var query = @"
                SELECT * FROM Branches b
                LEFT JOIN Branch_Members bm ON b.Id = bm.BranchId
                WHERE bm.Role = 'Moderator'";
        return await _dbConnection.QueryAsync<Branch>(query);
    }

    public async Task<Branch> GetBranchWithMembersAsync(int branchId)
    {
        var query = @"
                SELECT * FROM Branches b
                LEFT JOIN Branch_Members bm ON b.Id = bm.BranchId
                LEFT JOIN Users u ON bm.UserId = u.Id
                WHERE b.Id = @BranchId";
        return await _dbConnection.QueryFirstOrDefaultAsync<Branch>(query, new { BranchId = branchId });
    }
}
using System.Data;
using Branches_DAL.Entities;
using Branches_DAL.Repositories.Interfaces;
using Dapper;
using Npgsql;

namespace Branches_DAL.Repositories;

public class BranchMemberRepository : Repository<BranchMember>, IBranchMemberRepository
{
    public BranchMemberRepository(NpgsqlConnection dbConnection, IDbTransaction dbTransaction) : base(dbConnection, dbTransaction, "branch_members")
    {
    }

    public async Task<IEnumerable<BranchMember>> GetMembersByBranchIdAsync(int branchId)
    {
        var query = "SELECT * FROM Branch_Members WHERE BranchId = @BranchId";
        return await _dbConnection.QueryAsync<BranchMember>(query, new { BranchId = branchId });
    }

    public async Task<IEnumerable<BranchMember>> GetModeratorsByBranchIdAsync(int branchId)
    {
        var query = "SELECT * FROM Branch_Members WHERE BranchId = @BranchId AND Role = 'Moderator'";
        return await _dbConnection.QueryAsync<BranchMember>(query, new { BranchId = branchId });
    }
}
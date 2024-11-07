using System.Data;
using Branches_DAL.Entities;
using Branches_DAL.Repositories.Interfaces;
using Dapper;
using Npgsql;

namespace Branches_DAL.Repositories;

public class BranchRepository : Repository<Branch>, IBranchRepository
{
    public BranchRepository(NpgsqlConnection dbConnection, IDbTransaction dbTransaction) : base(dbConnection,
        dbTransaction, "branches")
    {
    }

    public async Task<IEnumerable<Branch>> GetBranchesWithModeratorsAsync()
    {
        var query = @"
            SELECT 
                b.Id, b.Name, b.Description, b.CreatedAt, b.UpdatedAt, 
                bm.Id, bm.BranchId, bm.UserId, bm.Role
            FROM Branches b
            LEFT JOIN Branch_Members bm ON b.Id = bm.BranchId
            WHERE bm.Role = 'Moderator'";

        var branchDictionary = new Dictionary<int, Branch>();

        var result = await _dbConnection.QueryAsync<Branch, BranchMember, Branch>(
            query,
            (branch, branchMember) =>
            {
                if (!branchDictionary.TryGetValue(branch.Id, out var currentBranch))
                {
                    currentBranch = branch;
                    branchDictionary.Add(branch.Id, currentBranch);
                }

                if (branchMember != null)
                    currentBranch.BranchMembers = currentBranch.BranchMembers.Append(branchMember);

                return currentBranch;
            },
            splitOn: "Id"
        );

        return result.Distinct();
    }

    public async Task<Branch> GetBranchWithMembersAsync(int branchId)
    {
        var query = @"
            SELECT 
                b.Id, b.Name, b.Description, b.CreatedAt, b.UpdatedAt, 
                bm.Id, bm.BranchId, bm.UserId, bm.Role, 
                u.Id, u.Name, u.Email
            FROM Branches b
            LEFT JOIN Branch_Members bm ON b.Id = bm.BranchId
            LEFT JOIN Users u ON bm.UserId = u.Id
            WHERE b.Id = @BranchId";

        var branchDictionary = new Dictionary<int, Branch>();

        var result = await _dbConnection.QueryAsync<Branch, BranchMember, User, Branch>(
            query,
            (branch, branchMember, user) =>
            {
                if (!branchDictionary.TryGetValue(branch.Id, out var currentBranch))
                {
                    currentBranch = branch;
                    branchDictionary.Add(branch.Id, currentBranch);
                }

                if (branchMember != null)
                {
                    branchMember.User = user;
                    currentBranch.BranchMembers = currentBranch.BranchMembers.Append(branchMember);
                }

                return currentBranch;
            },
            new { BranchId = branchId },
            splitOn: "Id,Id"
        );

        return result.FirstOrDefault();
    }
}
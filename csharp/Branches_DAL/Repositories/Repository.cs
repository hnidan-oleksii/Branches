using System.Data;
using Branches_DAL.Repositories.Interfaces;
using Dapper;
using Npgsql;

namespace Branches_DAL.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly NpgsqlConnection _dbConnection;
    protected readonly IDbTransaction _dbTransaction;
    protected readonly string _tableName;

    public Repository(NpgsqlConnection dbConnection,
        IDbTransaction dbTransaction,
        string tableName)
    {
        _dbConnection = dbConnection;
        _dbTransaction = dbTransaction;
        _tableName = tableName;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var result = await _dbConnection.QuerySingleOrDefaultAsync<T>(
            $"SELECT * FROM {_tableName} WHERE id = @Id",
            param: new { Id = id },
            transaction: _dbTransaction
        );

        if (result == null)
        {
            throw new KeyNotFoundException($"{typeof(T).Name} with id {id} could not be found.");
        }

        return result;
    }


    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var result = await _dbConnection.QueryAsync<T>(
            $"SELECT * FROM {_tableName}",
            transaction: _dbTransaction
        );
        if (result == null)
        {
            throw new KeyNotFoundException($"Couldn't retrieve entities from {nameof(T)}");
        }

        return result;
    }

    public async Task<int> AddAsync(T entity)
    {
        return await _dbConnection.ExecuteAsync(
            GenerateInsertQuery(),
            param: entity,
            transaction: _dbTransaction
        );
    }

    public async Task<int> UpdateAsync(T entity)
    {
        return await _dbConnection.ExecuteAsync(
            GenerateUpdateQuery(),
            param: entity,
            transaction: _dbTransaction
        );
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _dbConnection.ExecuteAsync(
            $"DELETE FROM {_tableName} WHERE Id = @Id",
            param: new { Id = id },
            transaction: _dbTransaction
        );
    }

    private string GenerateInsertQuery()
    {
        var properties = typeof(T).GetProperties().Select(p => p.Name).Where(p => p != "Id");
        var columns = string.Join(",", properties);
        var values = string.Join(",", properties.Select(p => $"@{p}"));
        return $"INSERT INTO {_tableName} ({columns}) VALUES ({values})";
    }

    private string GenerateUpdateQuery()
    {
        var properties = typeof(T).GetProperties().Where(p => p.Name != $"Id")
            .Select(p => $"{p.Name} = @{p.Name}");
        var setClause = string.Join(",", properties);
        return $"UPDATE {_tableName} SET {setClause} WHERE Id = @Id";
    }
}
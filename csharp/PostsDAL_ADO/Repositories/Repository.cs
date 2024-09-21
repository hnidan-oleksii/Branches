using System.Data;
using Dapper;
using Npgsql;
using PostsDAL_ADO.Repositories.Interfaces;

namespace PostsDAL_ADO.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly NpgsqlConnection _dbConnection;
    protected readonly IDbTransaction _dbTransaction;

    public Repository(NpgsqlConnection dbConnection, IDbTransaction dbTransaction)
    {
        _dbConnection = dbConnection;
        _dbTransaction = dbTransaction;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var result = await _dbConnection.QuerySingleOrDefaultAsync<T>(
            $"SELECT * FROM {typeof(T).Name}s WHERE Id = @Id",
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
            $"SELECT * FROM {typeof(T).Name}s",
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
            $"DELETE FROM {typeof(T).Name} WHERE Id = @Id",
            param: new { Id = id },
            transaction: _dbTransaction
        );
    }

    private string GenerateInsertQuery()
    {
        var properties = typeof(T).GetProperties().Select(p => p.Name).Where(p => p != "Id");
        var columns = string.Join(",", properties);
        var values = string.Join(",", properties.Select(p => $"@{p}"));
        return $"INSERT INTO {typeof(T).Name} ({columns}) VALUES ({values})";
    }

    private string GenerateUpdateQuery()
    {
        var properties = typeof(T).GetProperties().Where(p => p.Name != $"Id")
            .Select(p => $"{p.Name} = @{p.Name}");
        var setClause = string.Join(",", properties);
        return $"UPDATE {typeof(T).Name} SET {setClause} WHERE Id = @Id";
    }
}
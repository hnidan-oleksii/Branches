using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using PostsDAL_ADO.Repositories;
using PostsDAL_ADO.Repositories.Interfaces;
using PostsDAL_ADO.UoW;

namespace PostsDAL_ADO;

public static class ADOServiceRegistration
{
    public static IServiceCollection AddDapperRepositories(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<NpgsqlConnection>(_ => new NpgsqlConnection(connectionString));
        services.AddScoped<IDbTransaction>(s =>
        {
            var connection = s.GetRequiredService<NpgsqlConnection>();
            connection.Open();
            return connection.BeginTransaction();
        });

        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IPostVoteRepository, PostVoteRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
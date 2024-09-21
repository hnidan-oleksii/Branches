using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PostsDAL_EF.Context;
using PostsDAL_EF.Repositories;
using PostsDAL_EF.Repositories.Interfaces;
using PostsDAL_EF.UoW;

namespace PostsDAL_EF;

public static class EfServiceRegistration
{
    public static IServiceCollection AddEfRepositories(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IPostVoteRepository, PostVoteRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddDbContext<PostsContext>(options =>
        {
            options.EnableSensitiveDataLogging();
            options.UseNpgsql(connectionString);
        }); 

        return services;
    }
}
using System.Data;
using Branches_BLL.AutomapperProfiles;
using Branches_BLL.Services;
using Branches_BLL.Services.Interfaces;
using Branches_DAL.Repositories;
using Branches_DAL.Repositories.Interfaces;
using Branches_DAL.UoW;
using Branches_DAL.UoW.Interfaces;
using Branches.Middleware.Exceptions;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database + transactions
var connectionString = builder.Configuration.GetConnectionString("PgsqlConnection");
builder.Services.AddScoped<NpgsqlConnection>(_ => new NpgsqlConnection(connectionString));
builder.Services.AddScoped<IDbTransaction>(s =>
{
    var connection = s.GetRequiredService<NpgsqlConnection>();
    connection.Open();
    return connection.BeginTransaction();
});

// Repositories + UoW
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IBranchMemberRepository, BranchMemberRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Services
builder.Services.AddScoped<IBranchService, BranchService>();

// Automapper
builder.Services.AddAutoMapper(typeof(BranchMappingProfile).Assembly);

// Redis
builder.Services.AddStackExchangeRedisCache(opt =>
{
    opt.Configuration = "redis";
    opt.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions()
    {
        AbortOnConnectFail = true,
        EndPoints = { opt.Configuration }
    };
});

// Exception Handling
builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
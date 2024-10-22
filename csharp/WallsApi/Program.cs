using WallsInfrastructure.Data;
using WallsApplication.Common.Mappings;
using WallsApplication.WallPosts.Commands.CreateWallPost;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using WallsApplication.Common.Interfaces;
using WallsApi.Middleware.Exceptions;

var builder = WebApplication.CreateBuilder(args);

var pgsqlHost = Environment.GetEnvironmentVariable("PSQL_HOST");
var pgsqlPort = Environment.GetEnvironmentVariable("PSQL_PORT");
var pgsqlUser = Environment.GetEnvironmentVariable("PSQL_USER");
var pgsqlPass = Environment.GetEnvironmentVariable("PSQL_PASS");
var connectionString = $"Host={pgsqlHost};Port={pgsqlPort};Database=walls;Username={pgsqlUser};Password={pgsqlPass};";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IWallContext, WallContext>(options =>
{
	options.EnableSensitiveDataLogging();
	options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
});

// Automapper
builder.Services.AddAutoMapper(typeof(WallPostMappingProfile).Assembly);

// MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateWallPostCommand).Assembly));

// Fluent Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateWallPostCommandValidator>();

// Exception Handling
builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<WallContext>();
	dbContext.Database.Migrate();
}

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

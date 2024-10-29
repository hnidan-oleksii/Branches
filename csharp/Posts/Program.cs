using Microsoft.EntityFrameworkCore;
using Posts.Middleware.Exceptions;
using PostsBLL.AutomapperProfiles;
using PostsBLL.Grpc;
using PostsBLL.Services;
using PostsBLL.Services.Interfaces;
using PostsDAL_ADO;
using PostsDAL_EF;
using PostsDAL_EF.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080, o => o.Protocols =
        Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1);

    options.ListenAnyIP(8081, o => o.Protocols =
        Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2);
});

// Repositories + UoW
var connectionString = builder.Configuration.GetConnectionString("PgsqlConnection");
var useAdo = false;
if (useAdo)
    builder.Services.AddDapperRepositories(connectionString);
else
    builder.Services.AddEfRepositories(connectionString);

// Services
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostVoteService, PostVoteService>();

// Automapper
builder.Services.AddAutoMapper(typeof(PostMappingProfile).Assembly);

// Exception Handling
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

if (!useAdo)
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<PostsContext>();
        dbContext.Database.Migrate();
    }

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGrpcReflectionService();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGrpcService<PostsService>();
app.MapControllers();

app.Run();
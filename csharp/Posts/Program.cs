using Posts.Middleware.Exceptions;
using PostsBLL.AutomapperProfiles;
using PostsBLL.Services;
using PostsBLL.Services.Interfaces;
using PostsDAL_ADO;
using PostsDAL_EF;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
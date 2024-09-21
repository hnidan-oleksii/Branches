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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
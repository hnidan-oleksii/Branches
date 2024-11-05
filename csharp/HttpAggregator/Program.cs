using HttpAggregator.Services;
using HttpAggregator.Services.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1",
    new OpenApiInfo
    {
        Title = "HTTP Aggregator",
        Version = "v1"
    }));

builder.Services.AddHttpClient<IBranchService, BranchService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:BranchUrl"]));
builder.Services.AddHttpClient<IPostService, PostService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:PostUrl"]));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
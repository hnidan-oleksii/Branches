using Infrastructure.Data;
using Application.Common.Mappings;
using Application.WallPosts.Commands.CreateWallPost;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PgsqlConnection");
builder.Services.AddDbContext<IWallContext, WallContext>(options =>
{
	options.EnableSensitiveDataLogging();
	options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
}); 

// Automapper
builder.Services.AddAutoMapper(typeof(WallPostMappingProfile).Assembly);

// MediarR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateWallPostCommand).Assembly));

// Fluent Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateWallPostCommandValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

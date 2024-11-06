using GatewayOcelot.DefinedAggregator;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerForOcelot(builder.Configuration);

builder.Configuration.AddJsonFile("ocelot.json", false, true);
builder.Services.AddOcelot(builder.Configuration)
    .AddCacheManager(x => { x.WithDictionaryHandle(); })
    .AddSingletonDefinedAggregator<WallPostsCommentsAggregator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwaggerForOcelotUI(opt =>
        opt.PathToSwaggerGenerator = "/swagger/docs");

app.UseAuthorization();

app.MapControllers();

await app.UseOcelot();

app.Run();
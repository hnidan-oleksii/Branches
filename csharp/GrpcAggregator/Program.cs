using GrpcAggregator.Grpc.Protos.Comments;
using GrpcAggregator.Grpc.Protos.Posts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Grpc
builder.Services.AddGrpc();
builder.Services.AddGrpcClient<PostService.PostServiceClient>(o =>
{
    o.Address = new Uri(builder.Configuration["Grpc:PostsUrl"]);
    o.ChannelOptionsActions.Add(options =>
    {
        options.HttpHandler = new SocketsHttpHandler
        {
            EnableMultipleHttp2Connections = true
        };
    });
});

builder.Services.AddGrpcClient<CommentService.CommentServiceClient>(o =>
{
    o.Address = new Uri(builder.Configuration["Grpc:CommentsUrl"]);
    o.ChannelOptionsActions.Add(options =>
    {
        options.HttpHandler = new SocketsHttpHandler
        {
            EnableMultipleHttp2Connections = true
        };
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
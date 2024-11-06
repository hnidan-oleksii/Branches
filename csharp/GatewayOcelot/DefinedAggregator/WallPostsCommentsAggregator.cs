using GatewayOcelot.Models;

namespace GatewayOcelot.DefinedAggregator;

using Microsoft.AspNetCore.Http;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

public class WallPostsCommentsAggregator : IDefinedAggregator
{
    public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
    {
        var wallPostsResponse = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
        var wallPosts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WallPostDto>>(wallPostsResponse);

        var commentsResponse = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();
        var comments = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WallCommentDto>>(commentsResponse);

        foreach (var post in wallPosts)
            post.WallComments = (comments ?? []).Where(c => c.PostId == post.Id).ToList();

        var mergedResponse = Newtonsoft.Json.JsonConvert.SerializeObject(wallPosts);
        var stringContent = new StringContent(mergedResponse);

        return new DownstreamResponse(stringContent, System.Net.HttpStatusCode.OK,
            responses[0].Items.DownstreamResponse().Headers, "application/json");
    }
}
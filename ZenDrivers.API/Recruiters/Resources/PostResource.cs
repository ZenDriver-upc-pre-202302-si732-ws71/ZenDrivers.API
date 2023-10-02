using ZenDrivers.API.Communication.Resources;
using ZenDrivers.API.Shared.Domain.Models;

namespace ZenDrivers.API.Recruiters.Resources;

public class PostResource : PostSimpleResource
{
    public IEnumerable<LikeResource> Likes { get; set; } = null!;
    public IEnumerable<CommentResource> Comments { get; set; } = null!;
}
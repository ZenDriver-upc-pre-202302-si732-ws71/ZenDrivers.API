using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Recruiters.Domain.Repositories;
using ZenDrivers.API.Recruiters.Domain.Services;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Recruiters.Services;

public class PostService : CrudService<Post, int>, IPostService
{
    private readonly IPostRepository _postRepository;
    
    public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork, IGenericMap<Post, Post> genericMap) : base(postRepository, unitOfWork, genericMap)
    {
        _postRepository = postRepository;
        EntityName = "Post";
    }

    public async Task<IEnumerable<Post>> FindPostsByRecruiterId(int recruiterId)
    {
        return await _postRepository.FindPostsByRecruiterId(recruiterId);
    }
}
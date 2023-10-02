using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Domain.Repository;
using ZenDrivers.API.Communication.Domain.Services;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Domain.Services.Communication;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Communication.Services;

public class LikeService : CrudService<Like, int>, ILikeService
{
    private readonly ILikeRepository _likeRepository;
    public LikeService(ILikeRepository likeRepository, IUnitOfWork unitOfWork, IGenericMap<Like, Like> genericMap) : base(likeRepository, unitOfWork, genericMap)
    {
        _likeRepository = likeRepository;
    }

    public async Task RemoveByPostAndAccountIdAsync(int postId, int accountId)
    {
        var like = await _likeRepository.GetByPostAndAccountIdAsync(postId, accountId);
        if (like != null)
            await Remove(like);
    }

    public async Task<BaseResponse<Like>> GetByPostAndAccountIdAsync(int postId, int accountId)
    {
        var like = await _likeRepository.GetByPostAndAccountIdAsync(postId, accountId);
        return like == null ? BaseResponse<Like>.Of("Post not liked by user") : Entity(like);
    }
}
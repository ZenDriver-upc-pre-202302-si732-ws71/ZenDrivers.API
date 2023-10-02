using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Domain.Services.Communication;

namespace ZenDrivers.API.Communication.Domain.Services;

public interface ILikeService : ICrudService<Like, int>
{
    Task RemoveByPostAndAccountIdAsync(int postId, int accountId);
    Task<BaseResponse<Like>> GetByPostAndAccountIdAsync(int postId, int accountId);
}
using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Shared.Domain.Repositories;

namespace ZenDrivers.API.Communication.Domain.Repository;

public interface ILikeRepository : ICrudRepository<Like, int>
{
    Task<Like?> GetByPostAndAccountIdAsync(int postId, int accountId);
}
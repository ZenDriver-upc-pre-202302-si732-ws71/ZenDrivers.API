using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Shared.Domain.Repositories;

namespace ZenDrivers.API.Communication.Domain.Repository;

public interface ICommentRepository : ICrudRepository<Comment, int>
{
    public Task<IEnumerable<Comment>> FindByPostIdAsync(int postId);
    public Task<IEnumerable<Comment>> FindByAccountIdAsync(int accountId);
}
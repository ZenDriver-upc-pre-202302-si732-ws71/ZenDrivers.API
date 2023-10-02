using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Shared.Domain.Services;

namespace ZenDrivers.API.Communication.Domain.Services;

public interface ICommentService : ICrudService<Comment, int>
{
    public Task<IEnumerable<Comment>> FindByPostIdAsync(int postId);
    public Task<IEnumerable<Comment>> FindByAccountIdAsync(int accountId);
}
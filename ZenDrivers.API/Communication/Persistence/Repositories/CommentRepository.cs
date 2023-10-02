using Microsoft.EntityFrameworkCore;
using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Domain.Repository;
using ZenDrivers.API.Shared.Persistence.Contexts;
using ZenDrivers.API.Shared.Persistence.Repositories;

namespace ZenDrivers.API.Communication.Persistence.Repositories;

public class CommentRepository : CrudRepository<Comment, int>, ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context.PostsComments)
    {
    }

    public async Task<IEnumerable<Comment>> FindByPostIdAsync(int postId) =>
        await DataSet.Where(c => c.PostId == postId).ToListAsync();

    public async Task<IEnumerable<Comment>> FindByAccountIdAsync(int accountId) =>
        await DataSet.Where(c => c.AccountId == accountId).ToListAsync();
}
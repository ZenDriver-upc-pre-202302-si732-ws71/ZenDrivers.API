using Microsoft.EntityFrameworkCore;
using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Domain.Repository;
using ZenDrivers.API.Shared.Persistence.Contexts;
using ZenDrivers.API.Shared.Persistence.Repositories;

namespace ZenDrivers.API.Communication.Persistence.Repositories;

public class LikeRepository : CrudRepository<Like, int>, ILikeRepository
{
    public LikeRepository(AppDbContext context) : base(context.PostLikes)
    {
    }

    public async Task<Like?> GetByPostAndAccountIdAsync(int postId, int accountId) =>
        await DataSet.Where(l => l.PostId == postId && l.AccountId == accountId).FirstOrDefaultAsync();
}
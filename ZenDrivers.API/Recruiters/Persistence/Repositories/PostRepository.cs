using Microsoft.EntityFrameworkCore;
using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Recruiters.Domain.Repositories;
using ZenDrivers.API.Shared.Persistence.Contexts;
using ZenDrivers.API.Shared.Persistence.Repositories;

namespace ZenDrivers.API.Recruiters.Persistence.Repositories;

public class PostRepository : CrudRepository<Post, int>, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context.Posts)
    {
    }

    public async Task<IEnumerable<Post>> FindPostsByRecruiterId(int recruiterId)
    {
        return await DataSet
            .Where(p => p.RecruiterId == recruiterId)
            .ToListAsync();
    }
}
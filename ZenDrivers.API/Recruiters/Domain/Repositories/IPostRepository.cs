using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Shared.Domain.Repositories;

namespace ZenDrivers.API.Recruiters.Domain.Repositories;

public interface IPostRepository : ICrudRepository<Post, int>
{
    Task<IEnumerable<Post>> FindPostsByRecruiterId(int recruiterId);
}
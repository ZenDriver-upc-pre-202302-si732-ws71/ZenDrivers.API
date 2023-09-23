using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Shared.Domain.Services;

namespace ZenDrivers.API.Recruiters.Domain.Services;

public interface IPostService : ICrudService<Post, int>
{
    Task<IEnumerable<Post>> FindPostsByRecruiterId(int recruiterId);
}
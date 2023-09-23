using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Shared.Domain.Repositories;

namespace ZenDrivers.API.Recruiters.Domain.Repositories;

public interface IRecruiterRepository : ICrudRepository<Recruiter, int>
{
}
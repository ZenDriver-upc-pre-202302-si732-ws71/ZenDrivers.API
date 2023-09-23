using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Recruiters.Domain.Repositories;
using ZenDrivers.API.Shared.Persistence.Contexts;
using ZenDrivers.API.Shared.Persistence.Repositories;

namespace ZenDrivers.API.Recruiters.Persistence.Repositories;

public class RecruiterRepository : CrudRepository<Recruiter, int>, IRecruiterRepository
{
    public RecruiterRepository(AppDbContext context) : base(context.Recruiters)
    {
    }
    
}
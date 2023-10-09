using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<Recruiter>> FindByCompanyIdAsync(int companyId) =>
        await DataSet.Where(r => r.CompanyId == companyId).ToListAsync();

    public async Task<Recruiter?> FindByUsernameAsync(string username) =>
        await DataSet.Where(r => r.Account.Username == username).FirstOrDefaultAsync();
}
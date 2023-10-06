using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Repositories;
using ZenDrivers.API.Drivers.Domain.Repositories.Communication;
using ZenDrivers.API.Shared.Persistence.Contexts;
using ZenDrivers.API.Shared.Persistence.Repositories;

namespace ZenDrivers.API.Drivers.Persistence.Repositories;

public class DriverRepository : CrudRepository<Driver, int>, IDriverRepository
{
    public DriverRepository(AppDbContext context) : base(context.Drivers)
    {
    }

    public async Task<Driver?> FindDriverByUsernameAsync(string username) =>
        await DataSet.Where(d => d.Account.Username == username).FirstOrDefaultAsync();

    public async Task<IEnumerable<Driver>> FindDriversByAsync(FindDriver findDriver) =>
        (await DataSet.ToListAsync())
            .Where(d => d.Licenses.Any(c => c.Category.Name == findDriver.LicenseCategoryName) 
                        && (d.Experiences.Any(e => e.YearsOfExperience() >= findDriver.YearsOfExperience) 
                            || findDriver.YearsOfExperience == 0));
}
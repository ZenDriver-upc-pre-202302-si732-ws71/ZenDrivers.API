using Microsoft.EntityFrameworkCore;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Repositories;
using ZenDrivers.API.Shared.Persistence.Contexts;
using ZenDrivers.API.Shared.Persistence.Repositories;

namespace ZenDrivers.API.Drivers.Persistence.Repositories;

public class DriverExperienceRepository : CrudRepository<DriverExperience, int>, IDriverExperienceRepository
{
    public DriverExperienceRepository(AppDbContext context) : base(context.DriverExperiences)
    {
    }

    public async Task<IEnumerable<DriverExperience>> FindAllByDriverId(int driverId)
    {
        return await DataSet.Where(e => e.DriverId == driverId).ToListAsync();
    }
}
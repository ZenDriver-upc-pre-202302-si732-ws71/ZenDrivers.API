using Microsoft.EntityFrameworkCore;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Repositories;
using ZenDrivers.API.Shared.Persistence.Contexts;
using ZenDrivers.API.Shared.Persistence.Repositories;

namespace ZenDrivers.API.Drivers.Persistence.Repositories;

public class LicenseRepository : CrudRepository<License, int>, ILicenseRepository
{
    public LicenseRepository(AppDbContext context) : base(context.Licenses)
    {
    }

    public async Task<IEnumerable<License>> FindByCategoryNameAsync(string categoryName) =>
        await DataSet.Where(l => l.Category.Name == categoryName).ToListAsync();

    public async Task<IEnumerable<License>> FindByDriverIdAsync(int driverId) =>
        await DataSet.Where(l => l.DriverId == driverId).ToListAsync();
}
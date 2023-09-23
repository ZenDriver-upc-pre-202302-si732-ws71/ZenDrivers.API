using Microsoft.EntityFrameworkCore;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Repositories;
using ZenDrivers.API.Shared.Persistence.Repositories;

namespace ZenDrivers.API.Drivers.Persistence.Repositories;

public class LicenseCategoryRepository : CrudRepository<LicenseCategory, int>, ILicenseCategoryRepository
{
    public LicenseCategoryRepository(DbSet<LicenseCategory> dataSet) : base(dataSet)
    {
    }
}
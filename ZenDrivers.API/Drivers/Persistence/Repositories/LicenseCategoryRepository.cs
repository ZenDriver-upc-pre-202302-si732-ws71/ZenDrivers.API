using Microsoft.EntityFrameworkCore;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Repositories;
using ZenDrivers.API.Shared.Persistence.Contexts;
using ZenDrivers.API.Shared.Persistence.Repositories;

namespace ZenDrivers.API.Drivers.Persistence.Repositories;

public class LicenseCategoryRepository : CrudRepository<LicenseCategory, int>, ILicenseCategoryRepository
{
    public LicenseCategoryRepository(AppDbContext context) : base(context.LicenseCategories)
    {
    }

    public LicenseCategory? FindById(int id) => DataSet.Find(id);

    public Task<LicenseCategory?> FindByNameAsync(string name) =>
        DataSet.Where(c => c.Name == name).FirstOrDefaultAsync();
}
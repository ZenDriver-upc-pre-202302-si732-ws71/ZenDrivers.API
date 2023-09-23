using System.ComponentModel;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Shared.Domain.Repositories;

namespace ZenDrivers.API.Drivers.Domain.Repositories;

public interface ILicenseCategoryRepository : ICrudRepository<LicenseCategory, int>
{
    public LicenseCategory? FindById(int id);
    public Task<LicenseCategory?> FindByNameAsync(string name);
}
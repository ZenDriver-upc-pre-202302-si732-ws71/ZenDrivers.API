using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Shared.Domain.Services;

namespace ZenDrivers.API.Drivers.Domain.Services;

public interface ILicenseCategoryService : ICrudService<LicenseCategory, int>
{
    public LicenseCategory? FindById(int id);
    public Task<LicenseCategory?> FindByNameAsync(string name);
}
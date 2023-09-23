using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Shared.Domain.Services;

namespace ZenDrivers.API.Drivers.Domain.Services;

public interface ILicenseService : ICrudService<License, int>
{
    public Task<IEnumerable<License>> FindByCategoryNameAsync(string categoryName);
}
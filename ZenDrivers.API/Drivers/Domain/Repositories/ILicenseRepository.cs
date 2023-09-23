using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Shared.Domain.Repositories;

namespace ZenDrivers.API.Drivers.Domain.Repositories;

public interface ILicenseRepository : ICrudRepository<License, int>
{
    public Task<IEnumerable<License>> FindByCategoryNameAsync(string categoryName);
}
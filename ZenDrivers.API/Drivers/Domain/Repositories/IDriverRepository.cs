using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Repositories.Communication;
using ZenDrivers.API.Shared.Domain.Repositories;

namespace ZenDrivers.API.Drivers.Domain.Repositories;

public interface IDriverRepository : ICrudRepository<Driver, int>
{
    Task<Driver?> FindDriverByUsernameAsync(string username);
    Task<IEnumerable<Driver>> FindDriversByAsync(FindDriver findDriver);
}
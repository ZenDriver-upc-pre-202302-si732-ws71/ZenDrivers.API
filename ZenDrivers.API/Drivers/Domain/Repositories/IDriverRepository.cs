using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Resources.Requests;
using ZenDrivers.API.Shared.Domain.Repositories;

namespace ZenDrivers.API.Drivers.Domain.Repositories;

public interface IDriverRepository : ICrudRepository<Driver, int>
{
}
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Repositories;
using ZenDrivers.API.Drivers.Domain.Services;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Drivers.Services;

public class DriverService : CrudService<Driver, int>, IDriverService
{
    public DriverService(IDriverRepository driverRepository, IUnitOfWork unitOfWork, IGenericMap<Driver, Driver> genericMap) : base(driverRepository, unitOfWork, genericMap)
    {
    }
}
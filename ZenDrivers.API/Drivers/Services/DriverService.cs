using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Repositories;
using ZenDrivers.API.Drivers.Domain.Repositories.Communication;
using ZenDrivers.API.Drivers.Domain.Services;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Domain.Services.Communication;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Drivers.Services;

public class DriverService : CrudService<Driver, int>, IDriverService
{
    private readonly IDriverRepository _driverRepository;
    public DriverService(IDriverRepository driverRepository, IUnitOfWork unitOfWork, IGenericMap<Driver, Driver> genericMap) : base(driverRepository, unitOfWork, genericMap)
    {
        _driverRepository = driverRepository;
    }

    public async Task<BaseResponse<Driver>> FindDriverByUsernameAsync(string username)
    {
        if (await _driverRepository.FindDriverByUsernameAsync(username) is { } driver)
            return BaseResponse<Driver>.Of(driver);
        
        return BaseResponse<Driver>.Of($"Driver with {username} doesnt exist");
    }

    public async Task<IEnumerable<Driver>> FindDriversBy(FindDriver findDriver) =>
        await _driverRepository.FindDriversByAsync(findDriver);
}
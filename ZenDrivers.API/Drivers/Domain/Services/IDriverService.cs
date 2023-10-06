using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Repositories.Communication;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Domain.Services.Communication;

namespace ZenDrivers.API.Drivers.Domain.Services;

public interface IDriverService : ICrudService<Driver, int>
{
    Task<BaseResponse<Driver>> FindDriverByUsernameAsync(string username);
    Task<IEnumerable<Driver>> FindDriversBy(FindDriver findDriver);
}
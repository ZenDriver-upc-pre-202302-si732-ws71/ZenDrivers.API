using AutoMapper;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Resources.Update;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Drivers.Mapping;

public class DriverMap : GenericMap<Driver, DriverUpdateResource>
{
    public DriverMap(IMapper mapper) : base(mapper)
    {
    }
}
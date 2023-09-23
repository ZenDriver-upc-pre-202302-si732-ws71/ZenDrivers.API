using AutoMapper;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Resources.Update;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Drivers.Mapping;

public class LicenseMap : GenericMap<License, LicenseUpdateResource>
{
    public LicenseMap(IMapper mapper) : base(mapper)
    {
    }
}
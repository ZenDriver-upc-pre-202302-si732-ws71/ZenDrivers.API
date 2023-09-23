using AutoMapper;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Resources.Update;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Drivers.Mapping;

public class DriverExperienceMap : GenericMap<DriverExperience, DriverExperienceUpdateResource>
{
    public DriverExperienceMap(IMapper mapper) : base(mapper)
    {
    }
}
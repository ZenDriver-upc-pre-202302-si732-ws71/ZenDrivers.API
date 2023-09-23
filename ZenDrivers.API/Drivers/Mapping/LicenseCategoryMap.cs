using AutoMapper;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Resources.Update;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Drivers.Mapping;

public class LicenseCategoryMap : GenericMap<LicenseCategory, LicenseCategoryUpdateResource>
{
    public LicenseCategoryMap(IMapper mapper) : base(mapper)
    {
    }
}
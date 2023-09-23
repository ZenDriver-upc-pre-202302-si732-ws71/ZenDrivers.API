using AutoMapper;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Resources.Save;
using ZenDrivers.API.Drivers.Resources.Update;

namespace ZenDrivers.API.Drivers.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<DriverSaveResource, Driver>();
        CreateMap<LicenseSaveResource, License>();
        CreateMap<LicenseCategorySaveResource, License>();
        CreateMap<DriverExperienceSaveResource, DriverExperience>();
        
        CreateMap<DriverUpdateResource, Driver>();
        CreateMap<LicenseUpdateResource, License>();
        CreateMap<LicenseCategoryUpdateResource, LicenseCategory>();
        CreateMap<DriverExperienceUpdateResource, DriverExperience>();
    }
}
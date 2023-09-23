using AutoMapper;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Resources;
using ZenDrivers.API.Drivers.Resources.Update;
using ZenDrivers.API.Security.Resources;

namespace ZenDrivers.API.Drivers.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Driver, DriverResource>();
        CreateMap<License, LicenseResource>();
        CreateMap<LicenseCategory, LicenseCategoryResource>();
        CreateMap<DriverExperience, DriverExperienceResource>();
        CreateMap<Driver, AccountDriverResource>();
        
        CreateMap<Driver, DriverUpdateResource>();
        CreateMap<License, LicenseUpdateResource>();
        CreateMap<LicenseCategory, LicenseCategoryUpdateResource>();
        CreateMap<DriverExperience, DriverExperienceUpdateResource>();
    }
}
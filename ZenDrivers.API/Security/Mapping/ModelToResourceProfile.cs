using AutoMapper;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Recruiters.Resources;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Security.Domain.Services.Communication;
using ZenDrivers.API.Security.Resources;

namespace ZenDrivers.API.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Account, AuthenticateResponse>();
        CreateMap<Account, AccountResource>();
        CreateMap<Account, AccountSimpleResource>();


    }
}

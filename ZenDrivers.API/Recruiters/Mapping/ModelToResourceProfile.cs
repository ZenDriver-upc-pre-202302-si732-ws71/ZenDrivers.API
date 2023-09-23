using AutoMapper;
using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Recruiters.Resources;
using ZenDrivers.API.Recruiters.Resources.Update;
using ZenDrivers.API.Security.Resources;

namespace ZenDrivers.API.Recruiters.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Post, PostResource>();
        CreateMap<Recruiter, RecruiterResource>();
        CreateMap<Recruiter, AccountRecruiterResource>();
        CreateMap<Company, CompanyResource>();

        
        CreateMap<Post, PostUpdateResource>();
        CreateMap<Recruiter, RecruiterUpdateResource>();
        CreateMap<Company, CompanyUpdateResource>();
    }
}
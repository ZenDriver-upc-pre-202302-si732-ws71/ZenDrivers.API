using AutoMapper;
using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Recruiters.Resources.Save;
using ZenDrivers.API.Recruiters.Resources.Update;

namespace ZenDrivers.API.Recruiters.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<PostSaveResource, Post>();
        CreateMap<RecruiterSaveResource, Recruiter>();
        CreateMap<CompanySaveResource, Company>();
        
        CreateMap<PostUpdateResource, Post>();
        CreateMap<RecruiterUpdateResource, Recruiter>();
        CreateMap<CompanyUpdateResource, Company>();
    }
}
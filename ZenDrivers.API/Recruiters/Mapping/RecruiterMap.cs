using AutoMapper;
using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Security.Mapping;

public class RecruiterMap : GenericMap<Recruiter, Recruiter>
{
    public RecruiterMap(IMapper mapper) : base(mapper)
    { }
}
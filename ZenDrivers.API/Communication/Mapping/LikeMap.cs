using AutoMapper;
using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Resources.Update;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Communication.Mapping;

public class LikeMap : GenericMap<Like, LikeUpdateResource>
{
    public LikeMap(IMapper mapper) : base(mapper)
    {
    }
}
using AutoMapper;
using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Resources.Update;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Communication.Mapping;

public class CommentMap : GenericMap<Comment, CommentUpdateResource>
{
    public CommentMap(IMapper mapper) : base(mapper)
    {
    }
}
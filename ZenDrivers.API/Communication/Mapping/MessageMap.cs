using AutoMapper;
using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Resources.Update;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Communication.Mapping;

public class MessageMap : GenericMap<Message, MessageUpdateResource>
{
    public MessageMap(IMapper mapper) : base(mapper)
    {
    }
}
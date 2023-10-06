using AutoMapper;
using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Resources;
using ZenDrivers.API.Communication.Resources.Update;

namespace ZenDrivers.API.Communication.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Message, MessageResource>();
        CreateMap<Like, LikeResource>();
        CreateMap<Comment, CommentResource>();
        CreateMap<Conversation, ConversationResource>();

        CreateMap<Message, MessageUpdateResource>();
        CreateMap<Comment, CommentUpdateResource>();
    }
}
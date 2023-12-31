﻿using AutoMapper;
using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Resources.Save;
using ZenDrivers.API.Communication.Resources.Update;

namespace ZenDrivers.API.Communication.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<MessageSaveResource, Message>();
        CreateMap<LikeSaveResource, Like>();
        CreateMap<CommentSaveResource, Comment>();
        CreateMap<ConversationSaveResource, Conversation>();

        CreateMap<MessageUpdateResource, Message>();
        CreateMap<CommentUpdateResource, Comment>();
    }
}
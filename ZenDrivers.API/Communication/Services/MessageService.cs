using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Domain.Repository;
using ZenDrivers.API.Communication.Domain.Services;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Communication.Services;

public class MessageService : CrudService<Message, int>, IMessageService
{
    public MessageService(
        IMessageRepository messageRepository, 
        IUnitOfWork unitOfWork, 
        IGenericMap<Message, Message> genericMap) : base(messageRepository, unitOfWork, genericMap)
    {}
   
}
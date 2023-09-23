using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Domain.Repository;
using ZenDrivers.API.Communication.Domain.Services;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Communication.Services;

public class MessageService : CrudService<Message, int>, IMessageService
{
    private readonly IMessageRepository _messageRepository;
    public MessageService(IMessageRepository messageRepository, IUnitOfWork unitOfWork, IGenericMap<Message, Message> genericMap) : base(messageRepository, unitOfWork, genericMap)
    {
        _messageRepository = messageRepository;
    }


    public async Task<IEnumerable<Message>> FindByReceiverUsernameAsync(string receiverUsername)
    {
        return await _messageRepository.FindByReceiverUsernameAsync(receiverUsername);
    }

    public async Task<IEnumerable<Message>> FindBySenderUsernameAsync(string senderUsername)
    {
        return await _messageRepository.FindBySenderUsernameAsync(senderUsername);
    }

    public async Task<IEnumerable<Message>> FindByReceiverAndSenderUsernameAsync(string receiverUsername, string senderUsername)
    {
        return await _messageRepository.FindByReceiverAndSenderUsernameAsync(receiverUsername, senderUsername);
    }
}
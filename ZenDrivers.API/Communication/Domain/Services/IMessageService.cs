using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Shared.Domain.Services;

namespace ZenDrivers.API.Communication.Domain.Services;

public interface IMessageService : ICrudService<Message, int>
{
    public Task<IEnumerable<Message>> FindByReceiverUsernameAsync(string receiverUsername);
    public Task<IEnumerable<Message>> FindBySenderUsernameAsync(string senderUsername);
    public Task<IEnumerable<Message>> FindByReceiverAndSenderUsernameAsync(string receiverUsername, string senderUsername);
}
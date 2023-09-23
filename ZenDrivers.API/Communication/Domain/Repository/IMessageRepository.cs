using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Shared.Domain.Repositories;

namespace ZenDrivers.API.Communication.Domain.Repository;

public interface IMessageRepository : ICrudRepository<Message, int>
{
    public Task<IEnumerable<Message>> FindByReceiverUsernameAsync(string receiverUsername);
    public Task<IEnumerable<Message>> FindBySenderUsernameAsync(string senderUsername);
    public Task<IEnumerable<Message>> FindByReceiverAndSenderUsernameAsync(string receiverUsername, string senderUsername);
}
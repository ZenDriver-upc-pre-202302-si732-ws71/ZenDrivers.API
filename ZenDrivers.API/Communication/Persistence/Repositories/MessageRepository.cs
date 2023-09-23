using Microsoft.EntityFrameworkCore;
using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Domain.Repository;
using ZenDrivers.API.Shared.Persistence.Contexts;
using ZenDrivers.API.Shared.Persistence.Repositories;

namespace ZenDrivers.API.Communication.Persistence.Repositories;

public class MessageRepository : CrudRepository<Message, int>, IMessageRepository
{
    public MessageRepository(AppDbContext context) : base(context.Messages)
    {
    }


    public async Task<IEnumerable<Message>> FindByReceiverUsernameAsync(string receiverUsername)
    {
        return await DataSet.Where(m => m.Receiver.Username == receiverUsername).ToListAsync();
    }

    public async Task<IEnumerable<Message>> FindBySenderUsernameAsync(string senderUsername)
    {
        return await DataSet.Where(m => m.Sender.Username == senderUsername).ToListAsync();
    }

    public async Task<IEnumerable<Message>> FindByReceiverAndSenderUsernameAsync(string receiverUsername, string senderUsername)
    {
        return await DataSet.Where(m => m.Receiver.Username == receiverUsername && m.Sender.Username == senderUsername)
            .ToListAsync();
    }
}
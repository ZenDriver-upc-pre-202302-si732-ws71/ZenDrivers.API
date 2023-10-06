using Microsoft.EntityFrameworkCore;
using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Domain.Repository;
using ZenDrivers.API.Shared.Domain.Services.Communication;
using ZenDrivers.API.Shared.Persistence.Contexts;
using ZenDrivers.API.Shared.Persistence.Repositories;

namespace ZenDrivers.API.Communication.Persistence.Repositories;

public class ConversationRepository : CrudRepository<Conversation, int>, IConversationRepository
{
    public ConversationRepository(AppDbContext context) : base(context.Conversations)
    {
    }

    public async Task<Conversation?> FindByUsernamesAsync(string firstUsername, string secondUsername) => 
        await DataSet
            .Where(c =>
                (c.Sender.Username == firstUsername && c.Receiver.Username == secondUsername) ||
                (c.Receiver.Username == firstUsername && c.Sender.Username == secondUsername))
            .FirstOrDefaultAsync();


    public async Task<IEnumerable<Conversation>> FindByUsernameAsync(string username) =>
        await DataSet
            .Where(c => c.Receiver.Username == username || c.Sender.Username == username)
            .ToListAsync();
}
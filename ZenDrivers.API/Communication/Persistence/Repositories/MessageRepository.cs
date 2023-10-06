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
    
}
using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Shared.Domain.Repositories;

namespace ZenDrivers.API.Communication.Domain.Repository;

public interface IMessageRepository : ICrudRepository<Message, int>
{
    
}
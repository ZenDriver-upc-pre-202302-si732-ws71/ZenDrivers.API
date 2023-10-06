using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services.Communication;

namespace ZenDrivers.API.Communication.Domain.Repository;

public interface IConversationRepository : ICrudRepository<Conversation, int>
{
    Task<Conversation?> FindByUsernamesAsync(string firstUsername, string secondUsername);
    Task<IEnumerable<Conversation>> FindByUsernameAsync(string username);
}
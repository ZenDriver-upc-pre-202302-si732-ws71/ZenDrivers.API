using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Domain.Services.Communication;

namespace ZenDrivers.API.Communication.Domain.Services;

public interface IConversationService : ICrudService<Conversation, int>
{
    Task<BaseResponse<Conversation>> FindByUsernamesAsync(string firstUsername, string secondUsername);
    Task<IEnumerable<Conversation>> FindByUsernameAsync(string username);
}
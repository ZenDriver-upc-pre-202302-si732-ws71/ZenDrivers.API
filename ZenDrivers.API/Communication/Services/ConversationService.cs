using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Domain.Repository;
using ZenDrivers.API.Communication.Domain.Services;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Domain.Services.Communication;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Communication.Services;

public class ConversationService : CrudService<Conversation, int>, IConversationService
{
    private readonly IConversationRepository _conversationRepository;
    public ConversationService(IConversationRepository conversationRepository, IUnitOfWork unitOfWork, IGenericMap<Conversation, Conversation> genericMap) : base(conversationRepository, unitOfWork, genericMap)
    {
        _conversationRepository = conversationRepository;
    }

    public async Task<BaseResponse<Conversation>> FindByUsernamesAsync(string firstUsername, string secondUsername)
    {
        if (await _conversationRepository.FindByUsernamesAsync(firstUsername, secondUsername) is { } conversation)
            return BaseResponse<Conversation>.Of(conversation);

        return BaseResponse<Conversation>.Of($"Conversation for {firstUsername} and {secondUsername} doesnt exists");
    }

    public async Task<IEnumerable<Conversation>> FindByUsernameAsync(string username) => await _conversationRepository.FindByUsernameAsync(username);
}
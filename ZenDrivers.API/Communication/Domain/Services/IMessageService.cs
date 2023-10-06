using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Shared.Domain.Services;

namespace ZenDrivers.API.Communication.Domain.Services;

public interface IMessageService : ICrudService<Message, int>
{

}
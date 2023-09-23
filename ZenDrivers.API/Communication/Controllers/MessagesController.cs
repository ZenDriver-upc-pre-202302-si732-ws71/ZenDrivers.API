using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Domain.Services;
using ZenDrivers.API.Communication.Resources;
using ZenDrivers.API.Communication.Resources.Requests;
using ZenDrivers.API.Communication.Resources.Save;
using ZenDrivers.API.Communication.Resources.Update;
using ZenDrivers.API.Security.Authorization.Attributes;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Security.Domain.Services;
using ZenDrivers.API.Security.Exceptions;
using ZenDrivers.API.Shared.Controller;

namespace ZenDrivers.API.Communication.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class MessagesController : CrudController<Message, int, MessageResource, MessageSaveResource, MessageUpdateResource>
{
    private readonly IAccountService _accountService;
    private readonly IMessageService _messageService;
    public MessagesController(IMessageService messageService, IAccountService accountService, IMapper mapper) : base(messageService, mapper)
    {
        _messageService = messageService;
        _accountService = accountService;
    }

    private Account GetAccountByUsername(string username, string exception)
    {
        var account = _accountService.FindByUsername(username);
        if (account == null)
            throw new AppException($"{exception} username is not a valid");
        return account;
    }
    
    protected override Message? FromSaveResourceToEntity(MessageSaveResource resource)
    {
        var entity = base.FromSaveResourceToEntity(resource);
        if (entity == null) 
            return entity;
        
        var account = GetAccountByUsername(resource.ReceiverUsername, "Receiver");
        entity.ReceiverId = account.Id;
        account = HttpContext.Items["User"] as Account;
        
        if (account == null)
            throw new AppException("Sender Account is not valid");
        
        entity.SenderId = account.Id;
        return entity;
    }

    [HttpGet]
    public override async Task<IEnumerable<MessageResource>> GetAllAsync()
    {
        return await base.GetAllAsync();
    }

    [HttpGet("{id:int}")]
    public override async Task<IActionResult> GetByIdAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }

    [HttpPost]
    public override async Task<IActionResult> PostAsync(MessageSaveResource resource)
    {
        return await base.PostAsync(resource);
    }

    [HttpPut("{id:int}")]
    public override async Task<IActionResult> PutAsync(int id, MessageUpdateResource resource)
    {
        return await base.PutAsync(id, resource);
    }

    [HttpDelete("{id:int}")]
    public override async Task<IActionResult> DeleteAsync(int id)
    {
        return await base.DeleteAsync(id);
    }

    [HttpGet("receiver/{receiverUsername}")]
    public async Task<IEnumerable<MessageResource>> GetByReceiverUsername(string receiverUsername)
    {
        return await _messageService.FindByReceiverUsernameAsync(receiverUsername);
    }

    [HttpGet("sender/{senderUsername}")]
    public async Task<IEnumerable<MessageResource>> GetBySenderUsername(string senderUsername)
    {
        return await _messageService.FindBySenderUsernameAsync(senderUsername);
    }

    [HttpGet("conversation")]
    public async Task<IEnumerable<MessageResource>> GetConversation(ConversationRequest request)
    {
        return await _messageService.FindByReceiverAndSenderUsernameAsync(request.ReceiverUsername,
            request.SenderUsername);
    }
}
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
using ZenDrivers.API.Shared.Extensions;

namespace ZenDrivers.API.Communication.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class MessagesController : CrudController<Message, int, MessageResource, MessageSaveResource, MessageUpdateResource>
{
    private readonly IMessageService _messageService;
    private readonly IAccountService _accountService;
    private readonly IConversationService _conversationService;
    public MessagesController(IMessageService messageService, IMapper mapper, IConversationService conversationService, IAccountService accountService) : base(messageService, mapper)
    {
        _messageService = messageService;
        _conversationService = conversationService;
        _accountService = accountService;
    }

    [NonAction]
    public override async Task<IEnumerable<MessageResource>> GetAllAsync()
    {
        return await base.GetAllAsync();
    }

    [NonAction]
    public override async Task<IActionResult> GetByIdAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }

    [HttpPost]
    public override async Task<IActionResult> PostAsync(MessageSaveResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var entity = FromSaveResourceToEntity(resource);
        if (HttpContext.Items["User"] is not Account account || entity == null) 
            return await PostEntityAsync(entity);
        
        var conversation = await _conversationService.FindByUsernamesAsync(account.Username, resource.ReceiverUsername);
        if (!conversation.Success)
        {
            var receiver = await _accountService.FindByUsernameAsync(resource.ReceiverUsername);
            if (receiver == null)
                return BadRequestResponse("User receiver doesnt exist");
            conversation = await _conversationService.SaveAsync(new Conversation {
                SenderId = account.Id,
                ReceiverId = receiver.Id
            });
        }

        if (!conversation.Success)
            return BadRequestResponse(conversation.Message);
        
        entity.AccountId = account.Id;
        entity.ConversationId = conversation.Resource.Id;
        
        return await PostEntityAsync(entity);
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
    
}
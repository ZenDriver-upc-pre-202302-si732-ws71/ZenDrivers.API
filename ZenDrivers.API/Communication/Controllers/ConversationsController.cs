using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Domain.Services;
using ZenDrivers.API.Communication.Resources;
using ZenDrivers.API.Communication.Resources.Save;
using ZenDrivers.API.Communication.Resources.Update;
using ZenDrivers.API.Security.Authorization.Attributes;
using ZenDrivers.API.Shared.Controller;

namespace ZenDrivers.API.Communication.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class ConversationsController : CrudController<Conversation, int, ConversationResource, ConversationSaveResource, ConversationUpdateResource>
{
    private readonly IConversationService _conversationService;
    public ConversationsController(IConversationService conversationService, IMapper mapper) : base(conversationService, mapper)
    {
        _conversationService = conversationService;
    }

    [HttpGet]
    public override async Task<IEnumerable<ConversationResource>> GetAllAsync()
    {
        return await base.GetAllAsync();
    }

    [HttpGet("{id:int}")]
    public override async Task<IActionResult> GetByIdAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }

    [NonAction]
    public override Task<IActionResult> PostAsync(ConversationSaveResource resource)
    {
        return base.PostAsync(resource);
    }

    [NonAction]
    public override Task<IActionResult> PutAsync(int id, ConversationUpdateResource resource)
    {
        return base.PutAsync(id, resource);
    }

    [HttpDelete("{id:int}")]
    public override async Task<IActionResult> DeleteAsync(int id)
    {
        return await base.DeleteAsync(id);
    }

    [HttpGet("user/{username}")]
    public async Task<IEnumerable<ConversationResource>> GetByUsernameAsync(string username) =>
        Mapper.Map<IEnumerable<ConversationResource>>(await _conversationService.FindByUsernameAsync(username));


    [HttpGet("user/")]
    public async Task<IActionResult> GetByUsernamesAsync([FromQuery] string firstUsername, [FromQuery] string secondUsername)
    {
        var result = await _conversationService.FindByUsernamesAsync(firstUsername, secondUsername);
        return result.Success ? Ok(FromEntityToResource(result.Resource)) : BadRequestResponse(result.Message);
    }
}
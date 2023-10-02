using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Domain.Services;
using ZenDrivers.API.Communication.Resources;
using ZenDrivers.API.Communication.Resources.Save;
using ZenDrivers.API.Communication.Resources.Update;
using ZenDrivers.API.Recruiters.Domain.Services;
using ZenDrivers.API.Security.Authorization.Attributes;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Shared.Controller;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Domain.Services.Communication;

namespace ZenDrivers.API.Communication.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
public class CommentsController : CrudController<Comment, int, CommentResource, CommentSaveResource, CommentUpdateResource>
{
    private readonly ICommentService _commentService;
    private readonly IPostService _postService;
    public CommentsController(ICommentService commentService, IPostService postService, IMapper mapper) : base(commentService, mapper)
    {
        _commentService = commentService;
        _postService = postService;
    }

    protected override Comment? FromSaveResourceToEntity(CommentSaveResource resource)
    {
        var comment = base.FromSaveResourceToEntity(resource);
        if (HttpContext.Items["User"] is Account account && comment != null)
            comment.AccountId = account.Id;
        return comment;
    }

    [NonAction]
    public override Task<IEnumerable<CommentResource>> GetAllAsync()
    {
        return base.GetAllAsync();
    }

    [NonAction]
    public override Task<IActionResult> GetByIdAsync(int id)
    {
        return base.GetByIdAsync(id);
    }
    
    [HttpPost]
    public override async Task<IActionResult> PostAsync(CommentSaveResource resource)
    {
        var response = await _postService.FindByIdAsync(resource.PostId);
        if (!response.Success) 
            return BadRequest(ErrorResponse.Of("Invalid post id"));
        
        return await base.PostAsync(resource);
    }
    
    [NonAction]
    public override Task<IActionResult> PutAsync(int id, CommentUpdateResource resource)
    {
        return base.PutAsync(id, resource);
    }

    [NonAction]
    public override Task<IActionResult> DeleteAsync(int id)
    {
        return base.DeleteAsync(id);
    }
}
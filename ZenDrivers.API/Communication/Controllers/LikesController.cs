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
using ZenDrivers.API.Shared.Domain.Services.Communication;

namespace ZenDrivers.API.Communication.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
public class LikesController : CrudController<Like, int, LikeResource, LikeSaveResource, LikeUpdateResource>
{
    private readonly ILikeService _likeService;
    private readonly IPostService _postService;
    public LikesController(ILikeService likeService, IPostService postService, IMapper mapper) : base(likeService, mapper)
    {
        _likeService = likeService;
        _postService = postService;
    }

    [NonAction]
    public override Task<IEnumerable<LikeResource>> GetAllAsync()
    {
        return base.GetAllAsync();
    }
    
    [NonAction]
    public override Task<IActionResult> GetByIdAsync(int id)
    {
        return base.GetByIdAsync(id);
    }

    protected override Like? FromSaveResourceToEntity(LikeSaveResource resource)
    {
        var like = base.FromSaveResourceToEntity(resource);
        if (HttpContext.Items["User"] is Account account && like != null)
            like.AccountId = account.Id;
        return like;
    }

    [HttpPost]
    public override async Task<IActionResult> PostAsync(LikeSaveResource resource)
    {
        var response = await _postService.FindByIdAsync(resource.PostId);
        if (!response.Success)
            return BadRequest(ErrorResponse.Of("Invalid post id"));
        
        if (HttpContext.Items["User"] is not Account account) 
            return BadRequest(ErrorResponse.Of("Invalid user"));;
        
        var like = await _likeService.GetByPostAndAccountIdAsync(resource.PostId, account.Id);
        if (like.Success)
            return BadRequest(ErrorResponse.Of(like.Message));
        
        return await base.PostAsync(resource);
    }

    [NonAction]
    public override Task<IActionResult> PutAsync(int id, LikeUpdateResource resource)
    {
        return base.PutAsync(id, resource);
    }

    [NonAction]
    public override Task<IActionResult> DeleteAsync(int id)
    {
        return base.DeleteAsync(id);
    }

    [HttpDelete("posts/{id:int}")]
    public async Task<IActionResult> DeleteByPostId(int id)
    {
        if (HttpContext.Items["User"] is not Account account)
            return BadRequest(ErrorResponse.Of("Invalid user"));

        await _likeService.RemoveByPostAndAccountIdAsync(id, account.Id);
        return Ok(ErrorResponse.Of("Like erased successfully"));
    }
    
}
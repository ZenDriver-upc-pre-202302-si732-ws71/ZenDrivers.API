using System.Collections.Immutable;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Recruiters.Domain.Services;
using ZenDrivers.API.Recruiters.Resources;
using ZenDrivers.API.Recruiters.Resources.Save;
using ZenDrivers.API.Recruiters.Resources.Update;
using ZenDrivers.API.Security.Authorization.Attributes;
using ZenDrivers.API.Security.Authorization.Handlers.Interfaces;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Security.Domain.Services;
using ZenDrivers.API.Shared.Controller;
using ZenDrivers.API.Shared.Domain.Enums;

namespace ZenDrivers.API.Recruiters.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class PostsController : CrudController<Post, int, PostResource, PostSaveResource, PostUpdateResource>
{
    private readonly IPostService _postService;
    private readonly IAccountService _accountService;
    
    public PostsController(IPostService postService, IMapper mapper, IAccountService accountService) : base(postService, mapper)
    {
        _postService = postService;
        _accountService = accountService;
    }

    protected override Post? FromSaveResourceToEntity(PostSaveResource resource)
    {
        var entity = base.FromSaveResourceToEntity(resource);
        if (HttpContext.Items["User"] is Account account && entity != null)
            entity.RecruiterId = account.Recruiter!.Id;
        return entity;
    }
    
    [Authorize(UserType.Recruiter)]
    [HttpPost]
    public override async Task<IActionResult> PostAsync(PostSaveResource resource)
    {
        return await base.PostAsync(resource);
    }
    
    [HttpGet]
    public override async Task<IEnumerable<PostResource>> GetAllAsync()
    {
        return await base.GetAllAsync();
    }
    
    [HttpGet("{id:int}")]
    public override async Task<IActionResult> GetByIdAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }

    

    [HttpPut("{id:int}")]
    public override async Task<IActionResult> PutAsync(int id, PostUpdateResource resource)
    {
        return await base.PutAsync(id, resource);
    }
    
    [HttpDelete("{id:int}")]
    public override async Task<IActionResult> DeleteAsync(int id)
    {
        return await base.DeleteAsync(id);
    }

    [HttpGet("recruiters/{recruiterUsername}")]
    public async Task<IEnumerable<PostResource>> GetByRecruiterUsername(string recruiterUsername)
    {
        var account = await _accountService.FindByUsernameAsync(recruiterUsername);
        if (account is { Success: false, Resource: not { Role: UserType.Recruiter } })
            return ImmutableList<PostResource>.Empty;
        
        var result = await _postService.FindPostsByRecruiterId(account.Resource.Recruiter!.Id);
        return result.Select(p => FromEntityToResource(p)!);
    }
}
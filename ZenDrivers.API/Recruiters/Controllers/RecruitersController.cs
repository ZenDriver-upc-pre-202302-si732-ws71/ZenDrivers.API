using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Recruiters.Domain.Services;
using ZenDrivers.API.Recruiters.Resources;
using ZenDrivers.API.Recruiters.Resources.Save;
using ZenDrivers.API.Recruiters.Resources.Update;
using ZenDrivers.API.Security.Authorization.Attributes;
using ZenDrivers.API.Shared.Controller;

namespace ZenDrivers.API.Recruiters.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class RecruitersController : CrudController<Recruiter, int, RecruiterResource, RecruiterSaveResource, RecruiterUpdateResource>
{
    private readonly IRecruiterService _recruiterService;
    public RecruitersController(IRecruiterService recruiterService, IMapper mapper) : base(recruiterService, mapper)
    {
        _recruiterService = recruiterService;
    }

    [NonAction]
    public override Task<IEnumerable<RecruiterResource>> GetAllAsync()
    {
        return base.GetAllAsync();
    }
    [NonAction]
    public override Task<IActionResult> GetByIdAsync(int id)
    {
        return base.GetByIdAsync(id);
    }
    [NonAction]
    public override Task<IActionResult> PostAsync(RecruiterSaveResource resource)
    {
        return base.PostAsync(resource);
    }
    [NonAction]
    public override Task<IActionResult> PutAsync(int id, RecruiterUpdateResource resource)
    {
        return base.PutAsync(id, resource);
    }
    [NonAction]
    public override Task<IActionResult> DeleteAsync(int id)
    {
        return base.DeleteAsync(id);
    }

    [HttpGet("company/{companyId:int}")]
    public async Task<IEnumerable<RecruiterResource>> FindByCompanyId(int companyId)
    {
        var result = await _recruiterService.FindByCompanyIdAsync(companyId);
        return Mapper.Map<IEnumerable<RecruiterResource>>(result);
    }

    [HttpGet("user/{username}")]
    public async Task<IActionResult> FindByUsernameAsync(string username)
    {
        var response = await _recruiterService.FindByUsernameAsync(username);
        return response.Success ? Ok(FromEntityToResource(response.Resource)) : BadRequestResponse(response.Message);
    }
}
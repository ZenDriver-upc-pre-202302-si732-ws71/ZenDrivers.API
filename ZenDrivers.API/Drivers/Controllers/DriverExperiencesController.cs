using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Services;
using ZenDrivers.API.Drivers.Resources;
using ZenDrivers.API.Drivers.Resources.Save;
using ZenDrivers.API.Drivers.Resources.Update;
using ZenDrivers.API.Security.Authorization.Attributes;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Security.Domain.Services;
using ZenDrivers.API.Shared.Controller;
using ZenDrivers.API.Shared.Domain.Enums;

namespace ZenDrivers.API.Drivers.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class DriverExperiencesController : CrudController<DriverExperience, int, DriverExperienceResource, DriverExperienceSaveResource, DriverExperienceUpdateResource>
{
    private readonly IAccountService _accountService;
    private readonly IDriverExperienceService _driverExperienceService;
    public DriverExperiencesController(IDriverExperienceService driverExperienceService, IAccountService accountService, IMapper mapper) : base(driverExperienceService, mapper)
    {
        _driverExperienceService = driverExperienceService;
        _accountService = accountService;
    }

    [HttpGet]
    public override async Task<IEnumerable<DriverExperienceResource>> GetAllAsync()
    {
        return await base.GetAllAsync();
    }

    [HttpGet("{id:int}")]
    public override async Task<IActionResult> GetByIdAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }

    protected override DriverExperience? FromSaveResourceToEntity(DriverExperienceSaveResource resource)
    {
        var entity = base.FromSaveResourceToEntity(resource);
        if (entity == null)
            return entity;
        if (HttpContext.Items["User"] is Account account)
            entity.DriverId = account.Driver!.Id;
        return entity;
    }

    [Authorize(UserType.Driver)]
    [HttpPost]
    public override async Task<IActionResult> PostAsync(DriverExperienceSaveResource resource)
    {
        return await base.PostAsync(resource);
    }

    [HttpPut("{id:int}")]
    public override async Task<IActionResult> PutAsync(int id, DriverExperienceUpdateResource resource)
    {
        return await base.PutAsync(id, resource);
    }
    
    [HttpDelete("{id:int}")]
    public override async Task<IActionResult> DeleteAsync(int id)
    {
        return await base.DeleteAsync(id);
    }

    [HttpGet("drivers/{driverUsername}")]
    public async Task<IEnumerable<DriverExperienceResource>> GetByDriverUsername(string driverUsername)
    {
        var user = await _accountService.FindByUsernameAsync(driverUsername);
        if (user is not { Role: UserType.Driver })
            return Array.Empty<DriverExperienceResource>();
        return await _driverExperienceService.FindAllByDriverIdAsync(user.Driver!.Id);
    }
    
}
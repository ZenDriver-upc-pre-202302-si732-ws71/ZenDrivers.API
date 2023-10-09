using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Repositories.Communication;
using ZenDrivers.API.Drivers.Domain.Services;
using ZenDrivers.API.Drivers.Resources;
using ZenDrivers.API.Drivers.Resources.Requests;
using ZenDrivers.API.Drivers.Resources.Save;
using ZenDrivers.API.Drivers.Resources.Update;
using ZenDrivers.API.Security.Authorization.Attributes;
using ZenDrivers.API.Security.Domain.Services;
using ZenDrivers.API.Shared.Controller;
using ZenDrivers.API.Shared.Domain.Enums;

namespace ZenDrivers.API.Drivers.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class DriversController : CrudController<Driver, int, DriverResource, DriverSaveResource, DriverUpdateResource>
{
    private readonly IDriverService _driverService;
    public DriversController(IDriverService driverService, IAccountService accountService, IDriverExperienceService driverExperienceService, IMapper mapper, ILicenseService licenseService) : base(driverService, mapper)
    {
        _driverService = driverService;
    }
    
    [HttpGet]
    public override Task<IEnumerable<DriverResource>> GetAllAsync()
    {
        return base.GetAllAsync();
    }
    [NonAction]
    public override Task<IActionResult> GetByIdAsync(int id)
    {
        return base.GetByIdAsync(id);
    }
    [NonAction]
    public override Task<IActionResult> PostAsync(DriverSaveResource resource)
    {
        return base.PostAsync(resource);
    }
    [NonAction]
    public override Task<IActionResult> PutAsync(int id, DriverUpdateResource resource)
    {
        return base.PutAsync(id, resource);
    }
    [NonAction]
    public override Task<IActionResult> DeleteAsync(int id)
    {
        return base.DeleteAsync(id);
    }

    [HttpPost("find")]
    public async Task<IEnumerable<DriverResource>> FindDriverBy([FromBody] FindDriverRequest request)
    {
        var drivers = await _driverService.FindDriversBy(new FindDriver
        {
            LicenseCategoryName = request.CategoryName,
            YearsOfExperience = request.YearsOfExperience
        });

        return Mapper.Map<IEnumerable<DriverResource>>(drivers);
    }

    [HttpGet("user/{username}")]
    public async Task<IActionResult> FindDriverByUsernameAsync(string username)
    {
        var response = await _driverService.FindDriverByUsernameAsync(username);

        return response.Success ? Ok(FromEntityToResource(response.Resource)) : BadRequestResponse(response.Message);
    }
}
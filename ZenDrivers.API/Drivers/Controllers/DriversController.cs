using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Services;
using ZenDrivers.API.Drivers.Resources;
using ZenDrivers.API.Drivers.Resources.Requests;
using ZenDrivers.API.Drivers.Resources.Save;
using ZenDrivers.API.Drivers.Resources.Update;
using ZenDrivers.API.Security.Authorization.Attributes;
using ZenDrivers.API.Security.Domain.Services;
using ZenDrivers.API.Security.Resources;
using ZenDrivers.API.Shared.Controller;
using ZenDrivers.API.Shared.Domain.Enums;

namespace ZenDrivers.API.Drivers.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class DriversController : CrudController<Driver, int, DriverResource, DriverSaveResource, DriverUpdateResource>
{
    private readonly IDriverService _driverService;
    private readonly IAccountService _accountService;
    private readonly IDriverExperienceService _driverExperienceService;
    private readonly ILicenseService _licenseService;
    public DriversController(IDriverService driverService, IAccountService accountService, IDriverExperienceService driverExperienceService, IMapper mapper, ILicenseService licenseService) : base(driverService, mapper)
    {
        _driverService = driverService;
        _accountService = accountService;
        _driverExperienceService = driverExperienceService;
        _licenseService = licenseService;
    }
    
    [NonAction]
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
    public async Task<IEnumerable<AccountResource>> FindDriverBy([FromBody] FindDriverRequest request)
    {
        var drivers = await _accountService.FindByUserRoleAsync(UserType.Driver);
        var resources = new List<AccountResource>();
        foreach (var driver in drivers)
        {
            var experiences = await _driverExperienceService.FindAllByDriverIdAsync(driver.Driver!.Id);
            var licenses = await _licenseService.FindByDriverIdAsync(driver.Driver!.Id);

            if (!licenses.IsNullOrEmpty() && (experiences.Any(e => e.YearsOfExperience() >= request.YearsOfExperience) || request.YearsOfExperience == 0))
                resources.Add(Mapper.Map<AccountResource>(driver));
        }

        return resources;
    }
}
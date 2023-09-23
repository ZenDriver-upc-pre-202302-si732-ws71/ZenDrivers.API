using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Services;
using ZenDrivers.API.Drivers.Resources;
using ZenDrivers.API.Drivers.Resources.Save;
using ZenDrivers.API.Drivers.Resources.Update;
using ZenDrivers.API.Security.Authorization.Attributes;
using ZenDrivers.API.Shared.Controller;
using ZenDrivers.API.Shared.Domain.Services;

namespace ZenDrivers.API.Drivers.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class LicenseCategoriesController : CrudController<LicenseCategory, int, LicenseCategoryResource, LicenseCategorySaveResource, LicenseCategoryUpdateResource>
{
    public LicenseCategoriesController(ILicenseCategoryService licenseCategoryService, IMapper mapper) : base(licenseCategoryService, mapper)
    {
    }

    [HttpGet]
    public override Task<IEnumerable<LicenseCategoryResource>> GetAllAsync()
    {
        return base.GetAllAsync();
    }

    [HttpGet("{id:int}")]
    public override Task<IActionResult> GetByIdAsync(int id)
    {
        return base.GetByIdAsync(id);
    }

    [HttpPost]
    public override Task<IActionResult> PostAsync(LicenseCategorySaveResource resource)
    {
        return base.PostAsync(resource);
    }

    [HttpPut("{id:int}")]
    public override Task<IActionResult> PutAsync(int id, LicenseCategoryUpdateResource resource)
    {
        return base.PutAsync(id, resource);
    }

    [HttpDelete("{id:int}")]
    public override Task<IActionResult> DeleteAsync(int id)
    {
        return base.DeleteAsync(id);
    }
}
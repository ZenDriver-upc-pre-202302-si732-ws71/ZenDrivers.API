using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Services;
using ZenDrivers.API.Drivers.Resources;
using ZenDrivers.API.Drivers.Resources.Save;
using ZenDrivers.API.Drivers.Resources.Update;
using ZenDrivers.API.Security.Authorization.Attributes;
using ZenDrivers.API.Shared.Controller;
using ZenDrivers.API.Shared.Domain.Services.Communication;

namespace ZenDrivers.API.Drivers.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class LicenseCategoriesController : CrudController<LicenseCategory, int, LicenseCategoryResource, LicenseCategorySaveResource, LicenseCategoryUpdateResource>
{
    private readonly ILicenseCategoryService _licenseCategoryService;
    public LicenseCategoriesController(ILicenseCategoryService licenseCategoryService, IMapper mapper) : base(licenseCategoryService, mapper)
    {
        _licenseCategoryService = licenseCategoryService;
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
    public override async Task<IActionResult> PostAsync(LicenseCategorySaveResource resource)
    {
        var category = await _licenseCategoryService.FindByNameAsync(resource.Name);
        if (category != null)
            return BadRequest(ErrorResponse.Of("Category already exists"));
        
        return await base.PostAsync(resource);
    }

    [HttpPut("{id:int}")]
    public override async Task<IActionResult> PutAsync(int id, LicenseCategoryUpdateResource resource)
    {
        return await base.PutAsync(id, resource);
    }

    [HttpDelete("{id:int}")]
    public override async Task<IActionResult> DeleteAsync(int id)
    {
        return await base.DeleteAsync(id);
    }
}
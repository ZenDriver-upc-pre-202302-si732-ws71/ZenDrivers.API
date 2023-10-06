using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Services;
using ZenDrivers.API.Drivers.Resources;
using ZenDrivers.API.Drivers.Resources.Save;
using ZenDrivers.API.Drivers.Resources.Update;
using ZenDrivers.API.Security.Authorization.Attributes;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Shared.Controller;
using ZenDrivers.API.Shared.Domain.Enums;
using ZenDrivers.API.Shared.Extensions;

namespace ZenDrivers.API.Drivers.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class LicensesController : CrudController<License, int, LicenseResource, LicenseSaveResource, LicenseUpdateResource>
{
    private readonly ILicenseService _licenseService;
    private readonly ILicenseCategoryService _licenseCategoryService;
    public LicensesController(ILicenseService licenseService, IMapper mapper, ILicenseCategoryService licenseCategoryService) : base(licenseService, mapper)
    {
        _licenseService = licenseService;
        _licenseCategoryService = licenseCategoryService;
    }

    [HttpGet]
    public override async Task<IEnumerable<LicenseResource>> GetAllAsync()
    {
        return await base.GetAllAsync();
    }

    [HttpGet("{id:int}")]
    public override async Task<IActionResult> GetByIdAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }

    protected override License? FromSaveResourceToEntity(LicenseSaveResource resource)
    {
        var entity =  base.FromSaveResourceToEntity(resource);
        if (entity == null)
            return entity;
        
        if (HttpContext.Items["User"] is Account account)
            entity.DriverId = account.Driver!.Id;
        
        return entity;
    }

    [Authorize(UserType.Driver)]
    [HttpPost]
    public override async Task<IActionResult> PostAsync(LicenseSaveResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var entity = FromSaveResourceToEntity(resource);
        if (entity == null) return await base.PostAsync(resource);
        
        var category = await _licenseCategoryService.FindByIdAsync(resource.CategoryId);
        if (!category.Success)
            return BadRequestResponse(category.Message);
        entity.CategoryId = category.Resource.Id;

        return await PostEntityAsync(entity);
    }

    [HttpDelete("{id:int}")]
    public override async Task<IActionResult> DeleteAsync(int id)
    {
        return await base.DeleteAsync(id);
    }
    
    [NonAction]
    public override Task<IActionResult> PutAsync(int id, LicenseUpdateResource resource)
    {
        return base.PutAsync(id, resource);
    }

    [HttpGet("category/{categoryName}")]
    public async Task<IEnumerable<LicenseResource>> GetByCategoryName(string categoryName)
    {
        var result = await _licenseService.FindByCategoryNameAsync(categoryName);
        return Mapper.Map<IEnumerable<LicenseResource>, IEnumerable<License>>(result);
    }
}
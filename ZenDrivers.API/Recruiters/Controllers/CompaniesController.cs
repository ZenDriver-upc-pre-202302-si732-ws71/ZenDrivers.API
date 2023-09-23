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
[Route("/api/v1/[controller]")]
public class CompaniesController : CrudController<Company, int, CompanyResource, CompanySaveResource, CompanyUpdateResource>
{
    private readonly ICompanyService _companyService;
    public CompaniesController(ICompanyService companyService, IMapper mapper) : base(companyService, mapper)
    {
        _companyService = companyService;
    }
    
    [HttpGet]
    public override async Task<IEnumerable<CompanyResource>> GetAllAsync()
    {
        return await base.GetAllAsync();
    }

    [HttpGet("{id:int}")]
    public override async Task<IActionResult> GetByIdAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }
    
    [HttpPost]
    public override async Task<IActionResult> PostAsync(CompanySaveResource resource)
    {
        return await base.PostAsync(resource);
    }

    [HttpPut("{id:int}")]
    public override async Task<IActionResult> PutAsync(int id, CompanyUpdateResource resource)
    {
        return await base.PutAsync(id, resource);
    }
    [HttpDelete("{id:int}")]
    public override async Task<IActionResult> DeleteAsync(int id)
    {
        return await base.DeleteAsync(id);
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Domain.Services.Communication;
using ZenDrivers.API.Shared.Extensions;

namespace ZenDrivers.API.Shared.Controller;

public class CrudController<TEntity, TId, TResource, TSaveResource, TUpdateResource> : ControllerBase
{
    protected readonly ICrudService<TEntity, TId> CrudService;
    protected readonly IMapper Mapper;

    protected IActionResult EntityNotExists(string entityName)
    {
        return BadRequest("The " + entityName + " not exists");
    }

    protected IActionResult BadRequestResponse(string message) => BadRequest(ErrorResponse.Of(message));

    protected CrudController(ICrudService<TEntity, TId> crudService, IMapper mapper)
    {
        CrudService = crudService;
        Mapper = mapper;
    }
    protected virtual TEntity? FromSaveResourceToEntity(TSaveResource resource)
    {
        return Mapper.Map<TSaveResource, TEntity>(resource);
    }
    protected virtual TResource? FromEntityToResource(TEntity entity)
    {
        return Mapper.Map<TEntity, TResource>(entity);
    }

    protected virtual TEntity? FromResourceToEntity(TResource resource)
    {
        return Mapper.Map<TResource, TEntity>(resource);
    }

    protected virtual TEntity? FromUpdateResourceToEntity(TUpdateResource resource)
    {
        return Mapper.Map<TUpdateResource, TEntity>(resource);
    }
    
    protected async Task<IActionResult> PostEntityAsync(TEntity? entity)
    {
        var result = await CrudService.SaveAsync(entity!);
        if (!result.Success)
            return BadRequestResponse(result.Message);

        var entityResource = FromEntityToResource(result.Resource);

        return Created(nameof(PostAsync), entityResource);
    }
    
    protected async Task<IActionResult> PutEntityAsync(TId id, TEntity? entity)
    {
        var result = await CrudService.UpdateAsync(id, entity!);

        if (!result.Success)
            return BadRequest(result.Message);

        var entityResource = FromEntityToResource(result.Resource);

        return Ok(entityResource);
    }
    
    
    public virtual async Task<IEnumerable<TResource>> GetAllAsync()
    {
        var entities = await CrudService.ListAsync();
        var resources = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TResource>>(entities);

        return resources;
    }
    
    public virtual async Task<IActionResult> GetByIdAsync(TId id)
    {
        var result = await CrudService.FindByIdAsync(id);
        if (!result.Success)
            return BadRequestResponse(result.Message);

        var entityResource = FromEntityToResource(result.Resource);

        return Ok(entityResource);
    }
    
    public virtual async Task<IActionResult> PostAsync([FromBody] TSaveResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var entity = FromSaveResourceToEntity(resource);

        return await PostEntityAsync(entity);
    }
    
    public virtual async Task<IActionResult> PutAsync(TId id, [FromBody] TUpdateResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var entity = FromUpdateResourceToEntity(resource);
        return await PutEntityAsync(id, entity);
    }
    
    public virtual async Task<IActionResult> DeleteAsync(TId id)
    {
        var result = await CrudService.DeleteAsync(id);
        if (!result.Success)
            return BadRequestResponse(result.Message);

        var entityResource = FromEntityToResource(result.Resource);

        return Ok(entityResource);
    }
    
}
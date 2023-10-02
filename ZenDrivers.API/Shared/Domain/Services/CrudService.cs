using ZenDrivers.API.Shared.Domain.Models;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services.Communication;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Shared.Domain.Services;

public class CrudService<TEntity, TId> : ICrudService<TEntity, TId> where TEntity : class, IBaseEntity<TId>
{
    private readonly ICrudRepository<TEntity, TId> _crudRepository;
    protected readonly IUnitOfWork UnitOfWork;
    protected string EntityName;
    private IGenericMap<TEntity, TEntity> GenericMap { get; }

    protected CrudService(ICrudRepository<TEntity, TId> crudRepository, IUnitOfWork unitOfWork, IGenericMap<TEntity, TEntity> genericMap)
    {
        this._crudRepository = crudRepository;
        this.UnitOfWork = unitOfWork;
        GenericMap = genericMap;
        this.EntityName = "Entity";
    }

    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await this._crudRepository.ListAsync();
    }

    protected async Task<BaseResponse<TEntity>> Remove(TEntity entity)
    {
        try
        {
            this._crudRepository.Remove(entity);
            await UnitOfWork.CompleteAsync();
            return Entity(entity);
        }
        catch (Exception e)
        {
            return ErrorMessage("deleting", e);
        }
    }

    public virtual async Task<BaseResponse<TEntity>> SaveAsync(TEntity entity)
    {
        try
        {
            await this._crudRepository.AddAsync(entity);
            await this.UnitOfWork.CompleteAsync();
            return Entity(entity);
        }
        catch (Exception e)
        {
            return this.ErrorMessage("saving", e);
        }
    }

    public virtual async Task<BaseResponse<TEntity>> UpdateAsync(TId id, TEntity entity)
    {
        var existEntity = await this._crudRepository.FindByIdAsync(id);
        if(existEntity == null)
            return BaseResponse<TEntity>.Of(this.EntityName + " Not Found");

        //For update fields
        existEntity = GenericMap.Map(entity, existEntity);
        
        try
        {
            this._crudRepository.Update(existEntity);
            await UnitOfWork.CompleteAsync();
            return Entity(existEntity);
        }
        catch (Exception e)
        {
            return this.ErrorMessage("updating", e);
        }
    }

    public virtual async Task<BaseResponse<TEntity>> DeleteAsync(TId id)
    {
        var existEntity = await this._crudRepository.FindByIdAsync(id);
        if(existEntity == null)
            return BaseResponse<TEntity>.Of(this.EntityName + " Not Found");

        return await Remove(existEntity);
    }

    public async Task<BaseResponse<TEntity>> FindByIdAsync(TId id)
    {
        var existEntity = await _crudRepository.FindByIdAsync(id);
        return existEntity == null ? BaseResponse<TEntity>.Of(this.EntityName + " Not Found") : Entity(existEntity);
    }

    protected BaseResponse<TEntity> ErrorMessage(string what, Exception e)
    {
        return BaseResponse<TEntity>.Of("An error occurred while " + what + " the " + this.EntityName + $": {e.Message}");
    }

    protected static BaseResponse<TEntity> Entity(TEntity entity)
    {
        return BaseResponse<TEntity>.Of(entity);
    }

}
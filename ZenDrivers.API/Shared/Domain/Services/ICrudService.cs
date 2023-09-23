
using ZenDrivers.API.Shared.Domain.Services.Communication;

namespace ZenDrivers.API.Shared.Domain.Services;

public interface ICrudService<TEntity, in TId>
{
    Task<IEnumerable<TEntity>> ListAsync();
    Task<BaseResponse<TEntity>> SaveAsync(TEntity entity);
    Task<BaseResponse<TEntity>> UpdateAsync(TId id, TEntity entity);
    Task<BaseResponse<TEntity>> DeleteAsync(TId id);
    Task<BaseResponse<TEntity>> FindByIdAsync(TId id);
}
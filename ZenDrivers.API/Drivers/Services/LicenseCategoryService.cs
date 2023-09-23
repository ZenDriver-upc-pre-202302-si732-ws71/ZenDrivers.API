using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Services;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Drivers.Services;

public class LicenseCategoryService : CrudService<LicenseCategory, int>, ILicenseCategoryService
{
    public LicenseCategoryService(ICrudRepository<LicenseCategory, int> crudRepository, IUnitOfWork unitOfWork, IGenericMap<LicenseCategory, LicenseCategory> genericMap) : base(crudRepository, unitOfWork, genericMap)
    {
    }
}
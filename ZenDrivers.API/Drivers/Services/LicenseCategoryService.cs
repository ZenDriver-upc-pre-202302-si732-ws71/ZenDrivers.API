using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Repositories;
using ZenDrivers.API.Drivers.Domain.Services;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Drivers.Services;

public class LicenseCategoryService : CrudService<LicenseCategory, int>, ILicenseCategoryService
{
    private readonly ILicenseCategoryRepository _licenseCategoryRepository;
    public LicenseCategoryService(ILicenseCategoryRepository licenseCategoryRepository, IUnitOfWork unitOfWork, IGenericMap<LicenseCategory, LicenseCategory> genericMap) : base(licenseCategoryRepository, unitOfWork, genericMap)
    {
        _licenseCategoryRepository = licenseCategoryRepository;
    }

    public LicenseCategory? FindById(int id) => _licenseCategoryRepository.FindById(id);
    public Task<LicenseCategory?> FindByNameAsync(string name) => _licenseCategoryRepository.FindByNameAsync(name);
}
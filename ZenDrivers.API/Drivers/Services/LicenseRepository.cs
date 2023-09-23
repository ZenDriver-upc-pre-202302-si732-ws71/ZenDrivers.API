using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Repositories;
using ZenDrivers.API.Drivers.Domain.Services;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Drivers.Services;

public class LicenseService : CrudService<License, int>, ILicenseService
{
    private readonly ILicenseRepository _licenseRepository;
    public LicenseService(ILicenseRepository licenseRepository, IUnitOfWork unitOfWork, IGenericMap<License, License> genericMap) : base(licenseRepository, unitOfWork, genericMap)
    {
        _licenseRepository = licenseRepository;
    }

    public async Task<IEnumerable<License>> FindByCategoryNameAsync(string categoryName)
    {
        return await _licenseRepository.FindByCategoryNameAsync(categoryName);
    }
}
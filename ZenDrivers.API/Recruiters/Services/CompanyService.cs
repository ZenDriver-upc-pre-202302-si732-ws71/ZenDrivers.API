using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Recruiters.Domain.Repositories;
using ZenDrivers.API.Recruiters.Domain.Services;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Recruiters.Services;

public class CompanyService : CrudService<Company, int>, ICompanyService
{
    public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork, IGenericMap<Company, Company> genericMap) : base(companyRepository, unitOfWork, genericMap)
    {
    }
}
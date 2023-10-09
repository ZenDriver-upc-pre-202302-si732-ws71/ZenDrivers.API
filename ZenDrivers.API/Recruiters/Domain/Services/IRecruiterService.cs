using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Domain.Services.Communication;

namespace ZenDrivers.API.Recruiters.Domain.Services;

public interface IRecruiterService : ICrudService<Recruiter, int>
{
    Task<IEnumerable<Recruiter>> FindByCompanyIdAsync(int companyId);
    Task<BaseResponse<Recruiter>> FindByUsernameAsync(string username);
}
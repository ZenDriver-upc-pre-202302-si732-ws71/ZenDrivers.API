using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Recruiters.Domain.Repositories;
using ZenDrivers.API.Recruiters.Domain.Services;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services;
using ZenDrivers.API.Shared.Domain.Services.Communication;
using ZenDrivers.API.Shared.Mapping;

namespace ZenDrivers.API.Recruiters.Services;

public class RecruiterService : CrudService<Recruiter, int>, IRecruiterService
{
    private readonly IRecruiterRepository _recruiterRepository;
    
    public RecruiterService(IRecruiterRepository recruiterRepository, IUnitOfWork unitOfWork, IGenericMap<Recruiter, Recruiter> genericMap) 
        : base(recruiterRepository, unitOfWork, genericMap)
    {
        _recruiterRepository = recruiterRepository;
    }

    public async Task<IEnumerable<Recruiter>> FindByCompanyIdAsync(int companyId) =>
        await _recruiterRepository.FindByCompanyIdAsync(companyId);

    public async Task<BaseResponse<Recruiter>> FindByUsernameAsync(string username)
    {
        var recruiter = await _recruiterRepository.FindByUsernameAsync(username);
        return recruiter != null
            ? BaseResponse<Recruiter>.Of(recruiter)
            : BaseResponse<Recruiter>.Of($"Recruiter with username {username} doesnt exist");
    }
}
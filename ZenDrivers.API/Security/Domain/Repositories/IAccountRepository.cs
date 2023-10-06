using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Shared.Domain.Enums;

namespace ZenDrivers.API.Security.Domain.Repositories;
public interface IAccountRepository
{
    Task<IEnumerable<Account>> ListAsync();
    Task AddAsync(Account account);
    Task<Account?> FindByIdAsync(int id);
    Task<Account?> FindByUsernameAsync(string username);

    Task<IEnumerable<Account>> FindByUserRoleAsync(UserType role);
    
    public bool ExistsByUsername(string username);
    Account? FindById(int id);
    void Update(Account account);
    void Remove(Account account);
}

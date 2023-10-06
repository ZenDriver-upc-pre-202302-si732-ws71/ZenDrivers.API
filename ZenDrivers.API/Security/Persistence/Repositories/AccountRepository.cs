using Microsoft.EntityFrameworkCore;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Security.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Enums;
using ZenDrivers.API.Shared.Persistence.Contexts;
using ZenDrivers.API.Shared.Persistence.Repositories;

namespace ZenDrivers.API.Security.Persistence.Repositories;

public class AccountRepository : BaseRepository, IAccountRepository
{
    public AccountRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Account>> ListAsync()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task AddAsync(Account account)
    {
        await _context.Accounts.AddAsync(account);
    }

    public async Task<Account?> FindByIdAsync(int userId)
    {
        return await _context.Accounts.FindAsync(userId);
    }

    public async Task<Account?> FindByUsernameAsync(string username)
    {
        return await _context.Accounts.SingleOrDefaultAsync(x => x.Username == username);
    }

    public async Task<IEnumerable<Account>> FindByUserRoleAsync(UserType role)
    {
        return await _context.Accounts.Where(a => a.Role == role).ToListAsync();
    }


    public Account? FindById(int id)
    {
        return _context.Accounts.Find(id);
    }

    public bool ExistsByUsername(string username)
    {
        return _context.Accounts.Any(x => x.Username == username);
    }

    public void Update(Account account)
    {
        _context.Accounts.Update(account);
    }

    public void Remove(Account account)
    {
        _context.Accounts.Remove(account);
    }
}

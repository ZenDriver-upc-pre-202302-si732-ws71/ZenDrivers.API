using AutoMapper;
using ZenDrivers.API.Security.Authorization.Handlers.Interfaces;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Security.Domain.Repositories;
using ZenDrivers.API.Security.Domain.Services;
using ZenDrivers.API.Security.Domain.Services.Communication;
using ZenDrivers.API.Security.Exceptions;
using ZenDrivers.API.Shared.Domain.Enums;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Domain.Services.Communication;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ZenDrivers.API.Security.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly IJwtHandler _jwtHandler;
    private readonly IMapper _mapper;

    public AccountService(IJwtHandler jwtHandler, IMapper mapper, IAccountRepository accountRepository, IUnitOfWork unitOfWork)
    {
        _jwtHandler = jwtHandler;
        _mapper = mapper;
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
    }

    private AuthenticateResponse CredentialsResponse(Account user)
    {
        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = _jwtHandler.GenerateToken(user);
        
        return response;
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var user = await _accountRepository.FindByUsernameAsync(request.Username);

        if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
        {
            throw new AppException("Username or password is incorrect");
        }

        return CredentialsResponse(user);
    }

    public async Task<AuthenticateResponse> ChangePassword(string username, ChangePasswordRequest request)
    {
        if (await _accountRepository.FindByUsernameAsync(username) is not { } user ||
            !BCryptNet.Verify(request.CurrentPassword, user.PasswordHash))
        {
            throw new AppException("Username or current password is incorrect");
        }

        user.PasswordHash = BCryptNet.HashPassword(request.NewPassword);

        try
        {
            _accountRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error ocurred while updating the user password: {e.Message}");
        }

        return CredentialsResponse(user);
    }

    public async Task<Account?>  ValidateAsync(ValidationRequest request)
    {
        if (_jwtHandler.ValidateToken(request.Token) is not { } userId)
            return null;
        if (await _accountRepository.FindByIdAsync(userId) is { } account && account.Username == request.Username)
            return account;
        
        return null;
    }

    public async Task<IEnumerable<Account>> ListAsync()
    {
        return await _accountRepository.ListAsync();
    }

    public async Task<Account> GetByIdAsync(int id)
    {
        var user = await _accountRepository.FindByIdAsync(id);
        if (user == null) 
            throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task RegisterAsync(RegisterRequest request)
    {
        //Validate
        if (_accountRepository.ExistsByUsername(request.Username))
            throw new AppException("Username '" + request.Username + "' is already taken");
        // map model to new user object
        var account = _mapper.Map<Account>(request);
        switch (account.Role)
        {
            case UserType.Driver when account.Driver == null:
                throw new AppException("Invalid account information. Account is for Driver Role and Driver is null");
            case UserType.Driver:
                account.Recruiter = null;
                break;
            case UserType.Recruiter when account.Recruiter == null:
                throw new AppException("Invalid account information. Account is for Recruiter Role and Recruiter is null");
            case UserType.Recruiter:
                account.Driver = null;
                break;
            default:
                throw new AppException("Invalid account information. Account role not valid");
        }
        
        if (!account.ValidNames())
            throw new AppException("Invalid firstname or lastname");
        if (!account.ValidPhone())
            throw new AppException("Invalid phone number");
        
        //Hash password
        account.PasswordHash = BCryptNet.HashPassword(request.Password);
        // Save User
        try
        {
            await _accountRepository.AddAsync(account);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error ocurred while saving the user: {e.Message}");
        }
        
    }

    public async Task UpdateAsync(int id, UpdateRequest request)
    {
        var user = GetById(id);

        //Validate
        //if(_userRepository.ExistsByUsername(request.Username))
        //    throw new AppException("Username '" + request.Username + "' is already taken");
        // Hash password if it was entered
        
        

        //Copy model to user and save
        _mapper.Map(request, user);
        
        if (!user.ValidNames())
            throw new AppException("Invalid firstname or lastname");
        if (!user.ValidPhone())
            throw new AppException("Invalid phone number");
        user.ImageUrl = request.ImageUrl;
        
        switch (user.Role)
        {
            case UserType.Driver:
                user.Recruiter = null;
                break;
            case UserType.Recruiter:
                user.Driver = null;
                break;
            default: break;
        }
        try
        {
            _accountRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error ocurred while updating the user: {e.Message}");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var user = GetById(id);

        try
        {
            _accountRepository.Remove(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error ocurred while deleting the user : {e.Message}");
        }
    }

    public async Task<BaseResponse<Account>> FindByUsernameAsync(string username)
    {
        var account = await _accountRepository.FindByUsernameAsync(username);

        return account != null
            ? BaseResponse<Account>.Of(account)
            : BaseResponse<Account>.Of($"User with username {username} doesnt exist");
    }

    //helper methods
    private Account GetById(int id)
    {
        var user = _accountRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
    
}

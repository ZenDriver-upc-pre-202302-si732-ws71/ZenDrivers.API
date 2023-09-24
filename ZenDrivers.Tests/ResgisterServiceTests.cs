using AutoMapper;
using Moq;
using ZenDrivers.API.Security.Authorization.Handlers.Interfaces;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Security.Domain.Repositories;
using ZenDrivers.API.Security.Exceptions;
using ZenDrivers.API.Security.Services;
using ZenDrivers.API.Shared.Domain.Enums;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.Tests.Builders;

namespace ZenDrivers.Tests;

public class Tests
{

    private Mock<IAccountRepository> _mockAccountRepository;
    private Mock<IUnitOfWork> _mockUnitOfWork;
    private Mock<IJwtHandler> _mockJwtHandler;
    private Mock<IMapper> _mockMapper;
    private AccountService _accountService;

    [SetUp]
    public void SetUp()
    {
        _mockAccountRepository = new Mock<IAccountRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockJwtHandler = new Mock<IJwtHandler>();
        _mockMapper = new Mock<IMapper>();

        _accountService = new AccountService(
            _mockJwtHandler.Object,
            _mockMapper.Object,
            _mockAccountRepository.Object,
            _mockUnitOfWork.Object
        );
        
        _mockUnitOfWork.Setup(uow => uow.CompleteAsync())
            .Returns(Task.CompletedTask);
    }
    
    [Test]
    public Task RegisterDriverAsync_ValidRequest_UserDriverRegisteredSuccessfully()
    {
        // Arrange

        var request = new RegisterRequestBuilder()
            .WithUsername("username")
            .WithPassword("12345678")
            .WithRole(UserType.Driver.ToString())
            .WithDriver(
                new DriverSaveResourceBuilder()
                    .WithAddress("lima")
                    .Build()
                )
            .Build();

        
        _mockAccountRepository.Setup(repo => repo.ExistsByUsername(request.Username)).Returns(false);
        
        _mockMapper.Setup(mapper => mapper.Map<Account>(request))
            .Returns(
                new AccountBuilder()
                    .WithUsername("username")
                    .WithPasswordHash(BCryptNet.HashPassword(request.Password))
                    .WithRole(UserType.Driver)
                    .WithDriver(
                        new DriverBuilder()
                            .WithAddress("lima")
                            .Build()
                        )
                    .Build()
            );
        
        _mockAccountRepository.Setup(repo => repo.AddAsync(It.IsAny<Account>())).Returns(Task.CompletedTask);
        

        // Act
        async Task RegisterAction() => await _accountService.RegisterAsync(request);
        
        // Assert
        Assert.DoesNotThrowAsync(RegisterAction); // Ensure no exceptions are thrown
        return Task.CompletedTask;
    }
    
    [Test]
    public Task RegisterDriverAsync_InvalidRequest_UserDriverUsernameAlreadyExists()
    {
        // Arrange

        var request = new RegisterRequestBuilder()
            .WithUsername("username")
            .WithPassword("12345678")
            .WithRole(UserType.Driver.ToString())
            .WithDriver(
                new DriverSaveResourceBuilder()
                    .WithAddress("lima")
                    .Build()
            )
            .Build();

        
        _mockAccountRepository.Setup(repo => repo.ExistsByUsername(request.Username)).Returns(true);
        
        _mockMapper.Setup(mapper => mapper.Map<Account>(request))
            .Returns(
                new AccountBuilder()
                    .WithUsername("username")
                    .WithPasswordHash(BCryptNet.HashPassword(request.Password))
                    .WithRole(UserType.Driver)
                    .WithDriver(
                        new DriverBuilder()
                            .WithAddress("lima")
                            .Build()
                    )
                    .Build()
            );
        
        _mockAccountRepository.Setup(repo => repo.AddAsync(It.IsAny<Account>())).Returns(Task.CompletedTask);
        

        // Act
        async Task RegisterAction() => await _accountService.RegisterAsync(request);
        
        // Assert
        Assert.ThrowsAsync<AppException>(RegisterAction); // Ensure no exceptions are thrown
        return Task.CompletedTask;
    }
    
    [Test]
    public Task RegisterRecruiterAsync_ValidRequest_UserRecruiterRegisteredSuccessfully()
    {
        // Arrange

        var request = new RegisterRequestBuilder()
            .WithUsername("username")
            .WithPassword("12345678")
            .WithRole(UserType.Recruiter.ToString())
            .WithRecruiter(
                new RecruiterSaveResourceBuilder()
                    .WithEmail("recruiter@example.com")
                    .WithCompanyId(1)
                    .Build()
            )
            .Build();

        
        _mockAccountRepository.Setup(repo => repo.ExistsByUsername(request.Username)).Returns(false);
        _mockMapper.Setup(mapper => mapper.Map<Account>(request))
            .Returns(
                new AccountBuilder()
                    .WithUsername("username")
                    .WithPasswordHash(BCryptNet.HashPassword(request.Password))
                    .WithRole(UserType.Recruiter)
                    .WithRecruiter(
                        new RecruiterBuilder()
                            .WithEmail("recruiter@example.com")
                            .WithCompanyId(1)
                            .Build()
                    )
                    .Build()
            );
        
        _mockAccountRepository.Setup(repo => repo.AddAsync(It.IsAny<Account>())).Returns(Task.CompletedTask);
        

        // Act
        async Task RegisterAction() => await _accountService.RegisterAsync(request);
        
        // Assert
        Assert.DoesNotThrowAsync(RegisterAction); // Ensure no exceptions are thrown
        return Task.CompletedTask;
    }
    
    [Test]
    public Task RegisterRecruiterAsync_InvalidRequest_UserRecruiterUsernameAlreadyExists()
    {
        // Arrange
        var request = new RegisterRequestBuilder()
            .WithUsername("username")
            .WithPassword("12345678")
            .WithRole(UserType.Recruiter.ToString())
            .WithRecruiter(
                new RecruiterSaveResourceBuilder()
                    .WithEmail("recruiter@example.com")
                    .WithCompanyId(1)
                    .Build()
            )
            .Build();

        
        _mockAccountRepository.Setup(repo => repo.ExistsByUsername(request.Username)).Returns(true);
        _mockMapper.Setup(mapper => mapper.Map<Account>(request))
            .Returns(
                new AccountBuilder()
                    .WithUsername("username")
                    .WithPasswordHash(BCryptNet.HashPassword(request.Password))
                    .WithRole(UserType.Recruiter)
                    .WithRecruiter(
                        new RecruiterBuilder()
                            .WithEmail("recruiter@example.com")
                            .WithCompanyId(1)
                            .Build()
                    )
                    .Build()
            );
        
        _mockAccountRepository.Setup(repo => repo.AddAsync(It.IsAny<Account>())).Returns(Task.CompletedTask);
        

        // Act
        async Task RegisterAction() => await _accountService.RegisterAsync(request);
        
        // Assert
        Assert.ThrowsAsync<AppException>(RegisterAction); // Ensure no exceptions are thrown
        return Task.CompletedTask;
    }
}
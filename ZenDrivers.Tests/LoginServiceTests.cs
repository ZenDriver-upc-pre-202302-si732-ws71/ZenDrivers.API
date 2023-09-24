using AutoMapper;
using Moq;
using ZenDrivers.API.Security.Authorization.Handlers.Interfaces;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Security.Domain.Repositories;
using ZenDrivers.API.Security.Domain.Services.Communication;
using ZenDrivers.API.Security.Exceptions;
using ZenDrivers.API.Security.Services;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.Tests.Builders;

namespace ZenDrivers.Tests;

public class LoginServiceTests
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
    public async Task LoginUser_ValidRequest_LoginSuccessfully()
    {
        var request = new AuthenticateRequestBuilder()
            .WithUsername("username")
            .WithPassword("password")
            .Build();
        
        var user = new AccountBuilder()
            .WithUsername("username")
            .WithPasswordHash(BCryptNet.HashPassword("password"))
            .Build();
        
        const string token = "validtoken";
        
        _mockAccountRepository.Setup(repo => repo.FindByUsernameAsync(request.Username)).ReturnsAsync(user);
        _mockMapper.Setup(mapper => mapper.Map<AuthenticateResponse>(user))
            .Returns(
                new AuthenticateResponseBuilder()
                    .WithUsername("username")
                    .Build()
            );
        _mockJwtHandler.Setup(handler => handler.GenerateToken(user)).Returns(token);
        
        // Act
        var response = await _accountService.Authenticate(request);

        // Assert
        Assert.That(response.Token, Is.EqualTo(token));
    }
    
    [Test]
    public async Task LoginUser_InvalidRequest_UserDoesNotLogin()
    {
        var request = new AuthenticateRequestBuilder()
            .WithUsername("username")
            .WithPassword("pass")
            .Build();
        
        var user = new AccountBuilder()
            .WithUsername("username")
            .WithPasswordHash(BCryptNet.HashPassword("password"))
            .Build();

        const string token = "validtoken";
        const string exceptionMessage = "Username or password is incorrect";
        
        _mockAccountRepository.Setup(repo => repo.FindByUsernameAsync(request.Username))
            .ReturnsAsync(user);
        _mockMapper.Setup(mapper => mapper.Map<AuthenticateResponse>(user))
            .Returns(
                new AuthenticateResponseBuilder()
                    .WithUsername("username")
                    .Build()
            );
        _mockJwtHandler.Setup(handler => handler.GenerateToken(user))
            .Returns(token);
        
        try
        {
            // Act
            var response = await _accountService.Authenticate(request);
            throw new Exception();
        }
        catch (AppException e)
        {
            Assert.That(e.Message, Is.EqualTo(exceptionMessage));
        }
    }
}
using ZenDrivers.API.Security.Domain.Services.Communication;

namespace ZenDrivers.Tests.Builders;

public class AuthenticateRequestBuilder
{
    private string _username = "";
    private string _password = "";

    public AuthenticateRequest Build() =>
        new AuthenticateRequest
        {
            Username = _username,
            Password = _password
        };

    public AuthenticateRequestBuilder WithUsername(string value)
    {
        _username = value;
        return this;
    }

    public AuthenticateRequestBuilder WithPassword(string value)
    {
        _password = value;
        return this;
    }
}
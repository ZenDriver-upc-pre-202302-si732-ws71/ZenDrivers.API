using ZenDrivers.API.Security.Domain.Services.Communication;

namespace ZenDrivers.Tests.Builders;

public class AuthenticateResponseBuilder
{
    private int _id = 0;
    private string _firstName = "";
    private string _lastName = "";
    private string _username = "";
    private string _token = "";

    public AuthenticateResponse Build() =>
        new AuthenticateResponse
        {
            Id = _id,
            FirstName = _firstName,
            LastName = _lastName,
            Username = _username,
            Token = _token
        };

    public AuthenticateResponseBuilder WithId(int value)
    {
        _id = value;
        return this;
    }

    public AuthenticateResponseBuilder WithFirstName(string value)
    {
        _firstName = value;
        return this;
    }

    public AuthenticateResponseBuilder WithLastName(string value)
    {
        _lastName = value;
        return this;
    }

    public AuthenticateResponseBuilder WithUsername(string value)
    {
        _username = value;
        return this;
    }

    public AuthenticateResponseBuilder WithToken(string value)
    {
        _token = value;
        return this;
    }
}

using ZenDrivers.API.Drivers.Resources.Save;
using ZenDrivers.API.Recruiters.Resources.Save;
using ZenDrivers.API.Security.Domain.Services.Communication;

namespace ZenDrivers.Tests.Builders;
public class RegisterRequestBuilder
{
    private string _firstname = "";
    private string _lastname = "";
    private string _username = "";
    private string _password = "";
    private string _phone = "";
    private string _role = "";
    private RecruiterSaveResource? _recruiter = null;
    private DriverSaveResource? _driver = null;

    public RegisterRequest Build() =>
        new()
        {
            Firstname = _firstname,
            Lastname = _lastname,
            Username = _username,
            Password = _password,
            Phone = _phone,
            Role = _role,
            Recruiter = _recruiter,
            Driver = _driver,
        };

    public RegisterRequestBuilder WithFirstname(string value)
    {
        _firstname = value;
        return this;
    }

    public RegisterRequestBuilder WithLastname(string value)
    {
        _lastname = value;
        return this;
    }

    public RegisterRequestBuilder WithUsername(string value)
    {
        _username = value;
        return this;
    }

    public RegisterRequestBuilder WithPassword(string value)
    {
        _password = value;
        return this;
    }

    public RegisterRequestBuilder WithPhone(string value)
    {
        _phone = value;
        return this;
    }

    public RegisterRequestBuilder WithRole(string value)
    {
        _role = value;
        return this;
    }

    public RegisterRequestBuilder WithRecruiter(RecruiterSaveResource? value)
    {
        _recruiter = value;
        return this;
    }

    public RegisterRequestBuilder WithDriver(DriverSaveResource? value)
    {
        _driver = value;
        return this;
    }
    
}
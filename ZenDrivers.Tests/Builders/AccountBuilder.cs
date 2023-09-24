using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Shared.Domain.Enums;

namespace ZenDrivers.Tests.Builders;

public class AccountBuilder
{
    private int _id = 0;
    private string _firstname = "";
    private string _lastname = "";
    private string _username = "";
    private string _passwordHash = "";
    private UserType _role = UserType.Driver;
    private string _phone = "";
    private Recruiter? _recruiter = null;
    private Driver? _driver = null;

    public Account Build() =>
        new Account
        {
            Id = _id,
            Firstname = _firstname,
            Lastname = _lastname,
            Username = _username,
            PasswordHash = _passwordHash,
            Role = _role,
            Phone = _phone,
            Recruiter = _recruiter,
            Driver = _driver
        };

    public AccountBuilder WithId(int value)
    {
        _id = value;
        return this;
    }

    public AccountBuilder WithFirstname(string value)
    {
        _firstname = value;
        return this;
    }

    public AccountBuilder WithLastname(string value)
    {
        _lastname = value;
        return this;
    }

    public AccountBuilder WithUsername(string value)
    {
        _username = value;
        return this;
    }

    public AccountBuilder WithPasswordHash(string value)
    {
        _passwordHash = value;
        return this;
    }

    public AccountBuilder WithRole(UserType value)
    {
        _role = value;
        return this;
    }

    public AccountBuilder WithPhone(string value)
    {
        _phone = value;
        return this;
    }

    public AccountBuilder WithRecruiter(Recruiter? value)
    {
        _recruiter = value;
        return this;
    }

    public AccountBuilder WithDriver(Driver? value)
    {
        _driver = value;
        return this;
    }
}

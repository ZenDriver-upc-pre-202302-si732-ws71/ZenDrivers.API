using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Security.Domain.Models;

namespace ZenDrivers.Tests.Builders;

public class DriverBuilder
{
    private int _id = 0;
    private string _address = "";
    private DateTime _birth = new DateTime(1970, 1, 1);
    private Account _account = null!;
    private int _accountId = 0;

    public Driver Build() =>
        new Driver
        {
            Id = _id,
            Address = _address,
            Birth = _birth,
            Account = _account,
            AccountId = _accountId
        };

    public DriverBuilder WithId(int value)
    {
        _id = value;
        return this;
    }

    public DriverBuilder WithAddress(string value)
    {
        _address = value;
        return this;
    }

    public DriverBuilder WithBirth(DateTime value)
    {
        _birth = value;
        return this;
    }

    public DriverBuilder WithAccount(Account value)
    {
        _account = value;
        return this;
    }

    public DriverBuilder WithAccountId(int value)
    {
        _accountId = value;
        return this;
    }
}

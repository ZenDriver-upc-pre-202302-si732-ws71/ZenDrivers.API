using ZenDrivers.API.Drivers.Resources.Save;

namespace ZenDrivers.Tests.Builders;

public class DriverSaveResourceBuilder
{
    private string _address = "";
    private DateTime _birth = new DateTime(1970, 1, 1);

    public DriverSaveResource Build() =>
        new()
        {
            Address = _address,
            Birth = _birth
        };

    public DriverSaveResourceBuilder WithAddress(string value)
    {
        _address = value;
        return this;
    }

    public DriverSaveResourceBuilder WithBirth(DateTime value)
    {
        _birth = value;
        return this;
    }
}
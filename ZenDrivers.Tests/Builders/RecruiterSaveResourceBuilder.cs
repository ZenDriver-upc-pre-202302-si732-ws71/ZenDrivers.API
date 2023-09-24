using ZenDrivers.API.Recruiters.Resources.Save;

namespace ZenDrivers.Tests.Builders;

public class RecruiterSaveResourceBuilder
{
    private int _companyId = 0;
    private string _email = "";
    private string _description = "";

    public RecruiterSaveResource Build() =>
        new()
        {
            CompanyId = _companyId,
            Email = _email,
            Description = _description
        };

    public RecruiterSaveResourceBuilder WithCompanyId(int value)
    {
        _companyId = value;
        return this;
    }

    public RecruiterSaveResourceBuilder WithEmail(string value)
    {
        _email = value;
        return this;
    }

    public RecruiterSaveResourceBuilder WithDescription(string value)
    {
        _description = value;
        return this;
    }
}

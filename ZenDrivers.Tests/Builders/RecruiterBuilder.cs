using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Security.Domain.Models;

namespace ZenDrivers.Tests.Builders;

public class RecruiterBuilder
{
    private int _id = 0;
    private string _email = "";
    private string? _description = null;
    private int _companyId = 0;
    private int _accountId = 0;
    private Account _account = null!;

    public Recruiter Build() =>
        new()
        {
            Id = _id,
            Email = _email,
            Description = _description,
            CompanyId = _companyId,
            AccountId = _accountId,
            Account = _account
        };

    public RecruiterBuilder WithId(int value)
    {
        _id = value;
        return this;
    }

    public RecruiterBuilder WithEmail(string value)
    {
        _email = value;
        return this;
    }

    public RecruiterBuilder WithDescription(string? value)
    {
        _description = value;
        return this;
    }

    public RecruiterBuilder WithCompanyId(int value)
    {
        _companyId = value;
        return this;
    }

    public RecruiterBuilder WithAccountId(int value)
    {
        _accountId = value;
        return this;
    }

    public RecruiterBuilder WithAccount(Account value)
    {
        _account = value;
        return this;
    }
}
﻿using ZenDrivers.API.Recruiters.Resources;

namespace ZenDrivers.API.Security.Resources;

public class AccountRecruiterResource
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public CompanyResource Company { get; set; } = null!;
}
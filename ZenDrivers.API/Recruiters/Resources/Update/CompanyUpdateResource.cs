using System.ComponentModel.DataAnnotations;

namespace ZenDrivers.API.Recruiters.Resources.Update;

public class CompanyUpdateResource
{
    [Required] public string Name { get; set; } = null!;
    [Required] public string Address { get; set; } = null!;
}
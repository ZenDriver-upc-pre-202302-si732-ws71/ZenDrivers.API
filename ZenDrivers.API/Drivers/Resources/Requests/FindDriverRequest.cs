using System.ComponentModel.DataAnnotations;

namespace ZenDrivers.API.Drivers.Resources.Requests;

public class FindDriverRequest
{
    [Required] public int YearsOfExperience { get; set; }
    [Required] public string CategoryName { get; set; }
}
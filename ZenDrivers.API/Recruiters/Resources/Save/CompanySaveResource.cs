using System.ComponentModel.DataAnnotations;
using ZenDrivers.API.Recruiters.Resources.Update;

namespace ZenDrivers.API.Recruiters.Resources.Save;

public class CompanySaveResource : CompanyUpdateResource
{
   [Required] public string Ruc { get; set; } = null!;
   [Required] public string Owner { get; set; } = null!;
}
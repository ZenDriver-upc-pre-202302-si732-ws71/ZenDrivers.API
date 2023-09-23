using System.ComponentModel.DataAnnotations;
using ZenDrivers.API.Recruiters.Resources.Update;

namespace ZenDrivers.API.Recruiters.Resources.Save;

public class RecruiterSaveResource : RecruiterUpdateResource
{
    
    [Required]
    public int CompanyId { get; set; }
}